using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcommerceWebsite.Controllers
{
    public class CustomerSearchController : Controller
    {
        private readonly ICustomer _customer;
        public CustomerSearchController(ICustomer customer)
        {
            _customer = customer;
        }

        // GET: CustomerSearchController
        public ActionResult Index()
        {
            int cusotmerId = (int)TempData["CustomerId"];

            TempData.Keep("CustomerId");

            CustomerModel customer = _customer.SearchCustomer(cusotmerId);


            TempData["Fname"] = customer.Fname;
            TempData["Lname"] = customer.Lname;


            return View(customer);
        }

        public ActionResult SearchByName()
        {
            return View();
        }

        public ActionResult ViewDetail(List<CustomerModel> customers)
        {
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByName(SearchCustomerModel search)
        {
            List<CustomerModel> customers = _customer.SearchCustomer(search.Fname, search.Lname);

            if (ModelState.IsValid)
            {
                if (customers == null || customers.Count < 0)
                {
                    return RedirectToAction("Index");
                }

                return View("ViewDetail", customers);
            }
            return View(search);
        }

    }
}
