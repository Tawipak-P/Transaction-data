using Transaction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Transaction.Core.Services.Interfaces;
using AutoMapper;
using Serilog;
using Transaction.Core.Models;
using Transaction.Core.DTO;

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

                var file = _mapper.Map<FileUploadDTO>(fileUploadModel);
                switch (Path.GetExtension(fileUploadModel.TransactionFile.FileName))
                {
                    case ".csv":
                        response = await _tempTransactionService.UploadTransactionDataFromCSVAsync(file);
                        break;
                    default:
                        response = await _tempTransactionService.UploadTransactionDataFromXMLAsync(file);
                        break;
                }

                if (!response.IsSuccess)
                {
                    TempData["error"] = "Unsuccess to upload transaction data";
                    fileUploadModel.FileName = fileUploadModel.TransactionFile.FileName;
                    return View(fileUploadModel);
                }
                
                TempData["success"] = "Uploaded successfully";
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                TempData["error"] = "Unsuccess to upload transaction data";
                Log.Error(ex.ToString());
                fileUploadModel.FileName = fileUploadModel.TransactionFile.FileName;
                return View(fileUploadModel);
            }
        }
    }
}
