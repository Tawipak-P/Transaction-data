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
                var dataTable = new DataTable();
                switch (Path.GetExtension(file.TransactionFile.FileName))
                {
                    case ".csv":
                        dataTable = ConvertCSVToDataTable(file.TransactionFile);
                        break;
                    default:
                        dataTable = ConvertXmlToDataTable(file.TransactionFile);
                        break;
                }

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

        private DataTable ConvertXmlToDataTable(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = file.FileName.Split('.')[0] + '_' + DateTime.Now.Millisecond + extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/tempXmlFile", fileName);

            var dataTable = new DataTable();
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            try
            {
                var xml = File.ReadAllText(filePath);
                var xDocument = XDocument.Parse(xml);

                dataTable.Columns.Add("TransactionId");
                dataTable.Columns.Add("AccountNo");
                dataTable.Columns.Add("Amount");
                dataTable.Columns.Add("CurrencyCode");
                dataTable.Columns.Add("TransactionDate");
                dataTable.Columns.Add("Status");

                foreach (var data in xDocument.Descendants("Transaction"))
                {
                    var transactionId = data.Attribute("id").Value;
                    var accountNo = data.Element("PaymentDetails").Element("AccountNo").Value;
                    var amount = data.Element("PaymentDetails").Element("Amount").Value;
                    var currencyCode = data.Element("PaymentDetails").Element("CurrencyCode").Value;
                    var transactionDate = data.Element("TransactionDate").Value;
                    var status = data.Element("Status").Value;

                    dataTable.Rows.Add(transactionId, accountNo, amount, currencyCode, transactionDate, status);
                }
                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return dataTable;
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
