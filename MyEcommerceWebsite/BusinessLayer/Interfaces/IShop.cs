using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IShop
    {
        public Task<List<StoreModel>> GetAllStoresAsync();
        public List<ProductModel> GetProducts(int storeId);
        public Task<StoreModel> GetStoreById(int storeId);
        public Task<bool> AddItem(OrderModel order);
    }
}
