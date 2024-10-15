using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Globalization;
using System.Xml.Linq;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using Transaction.Infrastructor.Repositories.Interfaces;

namespace Transaction.Core.Services
{
    public class TempTransactionService : ITempTransactionService
    {
        private readonly ITempTransactionRepository _tempTransactionRepository;
        public TempTransactionService(ITempTransactionRepository tempTransactionRepository)
        {
            _tempTransactionRepository = tempTransactionRepository;
        }


        public async Task<ResponseModel> UploadTransactionWithSqlBlukCopyAsync(FileUploadModel file)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var dataTable = ConvertCSVToDataTable(file.TransactionFile);

                var results = await _tempTransactionRepository.UploadTransactionWithSqlBlukCopyAsync(dataTable);
                if (!results)
                {
                    response.IsSuccess = false;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private DataTable ConvertCSVToDataTable(IFormFile file)
        {
            var dataTable = new DataTable();
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    using (var csv = new CsvReader(streamReader, config))
                    {
                        csv.Read();
                        var dataReader = new CsvDataReader(csv);
                        dataTable.Load(dataReader);
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private XDocument ConvertXmlToXDocument(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = file.FileName.Split('.')[0] + '_' + DateTime.Now.Millisecond + extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/tempXmlFile", fileName);
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var xDocument = XDocument.Load(filePath);

                //clear file
                if (!String.IsNullOrEmpty(xDocument.ToString()))
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                return xDocument;
            }
            catch (Exception ex)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                throw ex;
            }
        }

    }
}
