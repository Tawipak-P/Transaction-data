﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using Transaction.Core.DTO;

namespace Transaction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ITempTransactionService _tempTransactionService;

        public TransactionApiController(ITransactionService transactionService, ITempTransactionService tempTransactionService)
        {
            _transactionService = transactionService;
            _tempTransactionService = tempTransactionService;
        }

        [HttpPost("upload-transaction-csv")]
        public async Task<IActionResult> UploadTransactionDataFromCSV(FileUploadModel fileUploadModel)
        {
            var response = new ResponseModel();
            try
            {
                response = await _tempTransactionService.UploadTransactionDataFromCSVAsync(fileUploadModel);
                if (!response.IsSuccess)
                {
                    response.IsSuccess = false;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                Log.Error(ex.ToString());
                return BadRequest(fileUploadModel);
            }
        }


        [HttpPost("upload-transaction-xml")]
        public async Task<IActionResult> UploadTransactionDataFromXML(FileUploadModel fileUploadModel)
        {
            var response = new ResponseModel();
            try
            {
                response = await _tempTransactionService.UploadTransactionDataFromXMLAsync(fileUploadModel);
                if (!response.IsSuccess)
                {
                    response.IsSuccess = false;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                Log.Error(ex.ToString());
                return BadRequest(fileUploadModel);
            }
        }



        [HttpPost("transaction-data")]
        public async Task<IActionResult> GetTransactionData(SearchCriteria searchCriteria)
        {
            var response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    Log.Error(ModelState.Values.SelectMany(e => e.Errors).ToArray().ToString());
                    return BadRequest();
                }
                response = await _transactionService.SearchTransactionDataAsync(searchCriteria);
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                Log.Error(ex.ToString());
                return BadRequest(response);
            }
        }

        [HttpGet("currencyCode-all")]
        public async Task<IActionResult> GetAllCurrencyCode()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response = await _transactionService.GetAllCurrencyCodeAsync();
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

        [HttpGet("status-all")]
        public async Task<IActionResult> GetAllStatus()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response = await _transactionService.GetAllStatusAsync();
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
