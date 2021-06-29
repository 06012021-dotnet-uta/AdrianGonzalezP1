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

            List<ProductModel> products = _shop.GetProducts(id);

            return View(products);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
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
