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


        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(OrderModel order)
        {
            bool isAdded;
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

                return RedirectToAction("Products", new { id = storeID } );
            }
            catch
            {
                return View();
            }
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
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

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
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
