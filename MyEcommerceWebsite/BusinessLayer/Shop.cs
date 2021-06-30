using Microsoft.EntityFrameworkCore;
using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Shop : IShop
    {

        private readonly MyEcommerceDb _;

        public Shop(MyEcommerceDb context)
        {
            _ = context;
        }

        /// <summary>
        /// Is responsible for getting all of the stores.
        /// </summary>
        /// <returns></returns>
        public async Task<List<StoreModel>> GetAllStoresAsync()
        {
            List<StoreModel> stores;
            try
            {
                stores = await Task.FromResult(_.Stores.ToList());
            }
            catch (Exception)
            {

                return null;
            }

            return stores;
        }

        /// <summary>
        /// Is responsible for getting all of the stores.
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts(int storeId)
        {
            var data = _.Inventories
                .Join(
                    _.Products,
                    inventory => inventory.ProductIdRef,
                    product => product.ProductId,
                    (inventory, product) => new { inventory, product })
                .Where(x => x.inventory.StoreIdRef == storeId)
                .Select(w => new ProductModel { 
                   ProductId = w.product.ProductId,
                   CategoryIdRef = w.product.CategoryIdRef,
                   ProductName = w.product.ProductName,
                   UnitPrice = w.product.UnitPrice,
                   Qunatity = w.inventory.Quantity,
                   Description = w.product.Description 
                }).ToList();

            return data;
        }

        public async Task<StoreModel> GetStoreById(int storeId)
        {
            StoreModel store;
            try
            {
                store = await _.Stores.SingleAsync(stores => stores.StoreId == storeId);
            }
            catch (InvalidOperationException)
            {

                return null;
            }
            catch (ArgumentNullException)
            {

                return null;
            }

            return store;
        }

        /// <summary>
        /// Responsible for checking to see if we can add item
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public async Task<bool> AddItem (OrderModel order)
        {
            bool isItemAdded;
            try
            {
                // Grab inventory with to check quantity
                InventoryModel inventory = await _.Inventories.SingleOrDefaultAsync(inventory => inventory.ProductIdRef == order.ProductIdRef);

                if(inventory != null &&  order.Quantity <= inventory.Quantity) 
                {
                    inventory.Quantity -= order.Quantity;
                    await _.SaveChangesAsync();
                    isItemAdded = true;
                }
                else
                {
                    isItemAdded = false;
                }
            }
            catch (InvalidOperationException)
            {

                return false;
            }
            catch (ArgumentNullException)
            {

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
            catch (DbUpdateException)
            {

                return false;
            }

            return isItemAdded;
        }
    }
}
