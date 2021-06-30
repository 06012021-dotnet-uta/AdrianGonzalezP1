using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcommerceWebsite.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShop _shop;


        public ShopController(IShop shop) 
        {
            _shop = shop;
        }


        // GET: Shop
        /// <summary>
        /// This method is reponsible for displaying all of the stores for the user to choose
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            List<StoreModel> stores = await _shop.GetAllStoresAsync();

            List <OrderModel> createOrder = new List<OrderModel>();

            TempData["Orders"] = JsonConvert.SerializeObject(createOrder);

            return View(stores);
        }


        // GET: Shop/Details/5
        /// <summary>
        /// Views the details of a store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            StoreModel stores = await _shop.GetStoreById(id);

            return View(stores);
        }

        // GET: Shop/Products/5
        public ActionResult Products(int id)
        {
            TempData["StoreId"] = id;

            List<ProductModel> products = _shop.GetProducts(id);

            return View(products);
        }

        // GET: Shop/Create
        public ActionResult AddItem(ProductModel product)
        {
            OrderModel order = new()
            {
                ProductIdRef = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Quantity = 0,

            };

            return View(order);
        }

       /// <summary>
       /// Customer Reviews order
       /// </summary>
       /// <returns></returns>
        public ActionResult OrderReview()
        {
            List<OrderModel> orders;
            int storeId = (int)TempData["StoreId"];
            int customerId = (int)TempData["CustomerId"];
            TempData.Keep("CustomerId");
            TempData.Keep("StoreId");
            decimal overAllTotal;

            try
            {
                orders = JsonConvert.DeserializeObject<List<OrderModel>>((string)TempData["Orders"]);

                overAllTotal = _shop.CalculateTotalAmount(orders, storeId,customerId);

                TempData["Orders"] = JsonConvert.SerializeObject(orders);


            }
            catch (ArgumentNullException)
            {

                return RedirectToAction("Index");
            }

            ViewData["OverAllTotal"] =  overAllTotal;

            return View(orders);
        }

        /// <summary>
        /// Checks out the customer and saves it to the databse
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> PlaceOrder()
        {
            List<OrderModel> orders;
            bool didSave;

            try
            {
                orders = JsonConvert.DeserializeObject<List<OrderModel>>((string)TempData["Orders"]);
                TempData.Keep("Orders");

                if (orders.Count > 0)
                {

                    didSave = await _shop.CheckoutAsync(orders);
                }
                else 
                {
                    return RedirectToAction("Index");
                }

            }
            catch (ArgumentNullException)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
        }


        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(OrderModel order)
        {
            bool isAdded;

            if (ModelState.IsValid) 
            {

                try
                {
                    isAdded = await _shop.AddItem(order);

                    if (isAdded)
                    {
                        List<OrderModel> orders = JsonConvert.DeserializeObject<List<OrderModel>>((string)TempData["Orders"]);
                        orders.Add(order);
                        TempData["Orders"] = JsonConvert.SerializeObject(orders);
                    }

                    int storeID = (int)TempData["StoreId"];
                    TempData.Keep("StoreId");

                    return RedirectToAction("Products", new { id = storeID });
                }
                catch
                {
                    return View();
                }

            }

            return View(order);
        }
    }
}
