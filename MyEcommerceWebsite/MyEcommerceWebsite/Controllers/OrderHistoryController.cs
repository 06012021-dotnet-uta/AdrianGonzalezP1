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
    public class OrderHistoryController : Controller
    {

        private readonly IOrderHistory _orderHistory;
        public OrderHistoryController(IOrderHistory orderHistory)
        {
            _orderHistory = orderHistory;
        }

        // GET: OrderHistoryController
        /// <summary>
        /// Displays all of the options that the user can make
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int cusotmerId = (int)TempData["CustomerId"];

            TempData.Keep("CustomerId");

            CustomerModel customer = _orderHistory.SearchCustomer(cusotmerId);


            TempData["Fname"] = customer.Fname;
            TempData["Lname"] = customer.Lname;


            return View(customer);
        }

        /// <summary>
        /// Lists all of the stores availabe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> HistoryByStore()
        {
            List<StoreModel> stores = await _orderHistory.GetAllStoresAsync();

            return View(stores);
        }

        // GET: OrderHistoryController/Create
        public ActionResult ViewOrder(int storeId, string storeName)
        {
            List<OrderModel> orders = _orderHistory.AllOrderHistoryByStoreId(storeId);

            TempData["StoreName"] = storeName;

            return View(orders);
        }

        public ActionResult CustomerOrders()
        {
            int cusotmerId = (int)TempData["CustomerId"];
            TempData.Keep("CustomerId");

            List<OrderModel> orders = _orderHistory.UsersOrders(cusotmerId);
            
           return View(orders);
        }

        public ActionResult AllOrders()
        {

            List<OrderModel> orders = _orderHistory.AllOrders();

            return View(orders);
        }
    }
}
