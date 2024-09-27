using Azure;
using Microsoft.AspNetCore.Mvc;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using TransactionData.Core.DTO;

namespace TransactionData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDataApiController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionDataApiController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost("transaction-data")]
        public async Task<IActionResult> GetTransactionData(SearchCriteria searchCriteria)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                response = await _transactionService.SearchTransactionDataAsync(searchCriteria);
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
    }
}
