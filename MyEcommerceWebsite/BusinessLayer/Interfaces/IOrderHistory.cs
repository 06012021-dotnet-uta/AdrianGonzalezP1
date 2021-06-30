using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IOrderHistory
    {

        public Task<List<StoreModel>> GetAllStoresAsync();

        public CustomerModel SearchCustomer(int customerId);

        public List<OrderModel> AllOrderHistoryByStoreId(int storeId);

        public List<OrderModel> UsersOrders(int storeId);

        public List<OrderModel> AllOrders();

    }
}
