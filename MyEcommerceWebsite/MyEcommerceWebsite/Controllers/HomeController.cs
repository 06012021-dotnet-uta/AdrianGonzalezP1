using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer;
using MyEcommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomer _customer;

        public HomeController(ILogger<HomeController> logger, ICustomer customer)
        {
            _logger = logger;
            _customer = customer;
        }

        public IActionResult Index(int id)
        {
            int cusotmerId = (int)TempData["CustomerId"];

            TempData.Keep("CustomerId");

            CustomerModel  customer = _customer.SearchCustomer(cusotmerId);

            return View(customer);
        }

        public IActionResult Privacy()
        {
            int cusotmerId = (int)TempData["CustomerId"];

            return View(cusotmerId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
