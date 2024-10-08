using Transaction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Transaction.Web.Services.Interfaces;
using Transaction.Web.DTO;
using Serilog;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transaction.Models;
using System.Collections.Generic;

namespace Transaction.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public HomeController(ITransactionService transactionService, IMapper mapper)
        {

            _transactionService = transactionService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(SearchCriteria searchCriteria)
        {
            try
            {
               
                ViewBag.CurrencyCodes = GetAllCurrencyCode().Select(c => 
                    new SelectListItem { Value = c.CurrencyCode, Text = c.CurrencyCode }
                ).ToList();

                ViewBag.Statuses = GetAllStatus().Select(s =>
                    new SelectListItem { Value = s.Name, Text = s.Name }
                ).ToList();

                if(searchCriteria.DateFrom == null)
                    searchCriteria.DateFrom = DateTime.Now.AddMonths(-1);
                if (searchCriteria.DateTo == null)
                    searchCriteria.DateTo = DateTime.Now;


                var response = await _transactionService.SearchAsync(searchCriteria);
                if (response == null)
                {
                    return View(new SearchCriteria());
                }

                ViewBag.Transactions = JsonConvert.DeserializeObject<List<TransactionModel>>(Convert.ToString(response.Result));
                return View(searchCriteria);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            return View(new SearchCriteria());
        }

        private List<CurrencyCodeModel> GetAllCurrencyCode()
        {
            try
            {
                var currencyCodes = new List<CurrencyCodeModel>();
                var response = _transactionService.GetAllCurrencyCodeAsync().GetAwaiter().GetResult();
                currencyCodes = JsonConvert.DeserializeObject<List<CurrencyCodeModel>>(Convert.ToString(response.Result));
                return currencyCodes;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return new List<CurrencyCodeModel>();
        }

        private List<StatusModel> GetAllStatus()
        {
            try
            {
                var statuses = new List<StatusModel>();
                var response = _transactionService.GetAllStatusAsync().GetAwaiter().GetResult();
                statuses = JsonConvert.DeserializeObject<List<StatusModel>>(Convert.ToString(response.Result));
                return statuses;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return new List<StatusModel>();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
