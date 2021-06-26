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
    public class SignupController : Controller
    {

        private readonly ISignup _signup;
        private string _account_username;
        private bool _isAccountCreated = false;
        private bool _isCustomerCreated = false;

        public SignupController(ISignup signup)
        {
            _signup = signup;
        }

        // GET: SignupController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignupController/Create
        /// <summary>
        /// Creates an account for a new customer
        /// </summary>
        /// <returns>The created view result object for the response</returns>
        public ActionResult CreateAccount()
        {
            return View();
        }

        //GET: SignupController/CreateCustomers
        /// <summary>
        /// For creating a customer. Asks for basic information
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCustomer(string username) 
        {
            return View();
        }

        // POST: SignupController/Create
        /// <summary>
        /// Is responsible for validating the creation of the account. If successful then it goes to the Create Customer
        /// View.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(AccountModel account)
        {
            if(ModelState.IsValid) 
            {
                _isAccountCreated = await _signup.CreateAccount(account);

                // Checks if account was added to DB successfully 
                if (_isAccountCreated)
                {
                    TempData["username"] = account.Username;
                    return RedirectToAction("CreateCustomer");
                }
                
            }

            return View(account);
        }

        // POST: SignupController/Create
        /// <summary>
        /// Is responsible for creating the customer. 
        /// If successfully added it will return to LoginPage.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCustomer(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                // Ref the username that was created from the account with.
                customer.UsernameRef = TempData["username"].ToString();

                _isCustomerCreated = await _signup.CreateCustomer(customer);

                // Checks if customer was succesfully added to the DB
                if (_isCustomerCreated)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(customer);
        }

        // GET: SignupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SignupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
