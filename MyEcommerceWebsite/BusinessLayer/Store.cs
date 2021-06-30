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
    public class Store: IStore
    {
        private readonly MyEcommerceDb _;

        public Store(MyEcommerceDb context)
        {
            _ = context;
        }

        /// <summary>
        /// Creates a store and stores it to the database
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<bool> Create(StoreModel store)
        {
            try
            {
                await _.Stores.AddAsync(store);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not add store {store.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes with given store id
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<bool> Delete(StoreModel store)
        {
            try
            {
                _.Stores.Remove(store);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not delete {store.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }

        public async Task<List<StoreModel>> GetAllStore()
        {

            try
            {
                List<StoreModel> stores = await Task.FromResult(_.Stores.ToList());

                return stores;
            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve all of stores\nError message {e.Message}");
                return null;
            }
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

        public StoreModel Read(string keyValue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(StoreModel store)
        {
            try
            {
                _.Stores.Update(store);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not update {store.StoreName}\nErro Message: {e.Message}");
                return false;
            }
        }
    }
}
