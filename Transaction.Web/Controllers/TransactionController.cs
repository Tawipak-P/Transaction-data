using Transaction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Transaction.Web.Services.Interfaces;
using AutoMapper;
using Serilog;
using Transaction.Web.DTO;

namespace Transaction.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITempTransactionService _tempTransactionService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITempTransactionService tempTransactionService, ITransactionService transactionService, IMapper mapper)
        {
            _tempTransactionService = tempTransactionService;
            _transactionService = transactionService;
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

                response = await _tempTransactionService.UploadTransactionWithSqlBlukCopyAsync(fileUploadModel);
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



        [HttpPost]
        public async Task<IActionResult> GetTransactionData(SearchCriteria searchCriteria)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    Log.Error(ModelState.Values.SelectMany(e => e.Errors).ToArray().ToString());
                    return BadRequest();
                }
                response = await _transactionService.SearchAsync(searchCriteria);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                Log.Error(ex.ToString());
                return BadRequest(response);
            }
        }
    }
}
