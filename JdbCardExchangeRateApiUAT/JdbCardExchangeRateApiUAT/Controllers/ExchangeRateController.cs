using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JDBCardExchageRate.ApiService;
using Microsoft.AspNetCore.Mvc;

namespace JDBCardExchageRate.Controllers
{
    [Route("api/uat/v1/[controller]")]
    [ApiController]
    public class ExchangeRateController : Controller
    {
         [HttpGet]
        public IActionResult Index()
        {
            return new Services().getExchangeRate();
        }
    }
}