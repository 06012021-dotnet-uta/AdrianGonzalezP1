using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IStore
    {
        public Task<bool> Create(StoreModel store);
        public Task<bool> Delete(StoreModel store);
        public Task<List<StoreModel>> GetAllStore();
        public Task<StoreModel> GetStoreById(int storeId);
        public StoreModel Read(string keyValue);
        public Task<bool> Update(StoreModel store);
    }
}
