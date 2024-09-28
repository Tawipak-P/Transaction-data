using Transaction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Transaction.Core.Services.Interfaces;
using Transaction.Core.Models;
using CsvHelper;
using System.Globalization;
using System.Data;
using CsvHelper.Configuration;
using System.Xml;
using AutoMapper;
using System.Xml.Linq;
using Serilog.Core;
using Serilog;

namespace Transaction.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITempTransactionService _tempTransactionService;
        private readonly IMapper _mapper;
        public TransactionController(ITempTransactionService tempTransactionService, IMapper mapper)
        {
            _tempTransactionService = tempTransactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UploadTransactionData()
        {
            ModelState.Clear();
            return View(new FileUploadModel());
        }


        [HttpPost]
        public async Task<IActionResult> UploadTransactionData(FileUploadModel fileUploadModel)
        {
            var response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    fileUploadModel.FileName = fileUploadModel.TransactionFile.FileName;
                    return View(fileUploadModel);
                }

                switch (Path.GetExtension(fileUploadModel.TransactionFile.FileName))
                {
                    case ".csv":
                        var dataTable = ConvertCSVToDataTable(fileUploadModel.TransactionFile);
                        response = await _tempTransactionService.UploadTransactionDataFromCSVAsync(dataTable);
                        break;
                    default:
                        var xDocument = ConvertXmlToXDocument(fileUploadModel.TransactionFile);
                        response = await _tempTransactionService.UploadTransactionDataFromXMLAsync(xDocument);
                        break;
                }

                if (response.IsSuccess)
                {
                    TempData["success"] = "Uploaded successfully";
                }

                ModelState.Clear();
                return View(fileUploadModel);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                TempData["error"] = "Unsuccess to upload transaction data";
                Log.Error(ex.ToString());
                ModelState.Clear();
                return View();
            }
        }

        private DataTable ConvertCSVToDataTable(IFormFile file)
        {
            var dataTable = new DataTable();

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
        private XDocument ConvertXmlToXDocument(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = file.FileName.Split('\\')[0] + '_' + DateTime.Now.Millisecond + extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/xml", fileName);
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
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                return xDocument;
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                throw ex;
            } 
        }

    }
}
