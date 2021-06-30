using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderHistory: IOrderHistory
    {
        private readonly MyEcommerceDb _;

        public OrderHistory(MyEcommerceDb context)
        {
            _ = context;
        }

        public List<OrderModel> AllOrderHistoryByStoreId(int storeId)
        {
            List<OrderModel> orders;

            try
            {
                orders = _.Orders.Where(order => order.StoreIdRef == storeId).ToList();
            }
            catch (Exception)
            {

                return null;
            }

            return orders;
        }

        public List<OrderModel> AllOrders()
        {
            List<OrderModel> orders;

            try
            {
                orders = _.Orders.ToList();
            }
            catch (Exception)
            {

                return null;
            }

            return orders;
        }

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

        public CustomerModel SearchCustomer(int customerId)
        {
            CustomerModel customer;
            try
            {
                customer = _.Customers.SingleOrDefault(c => c.CustomerId == customerId);
            }
            catch (InvalidOperationException)
            {

                return null;
            }
            catch (ArgumentNullException)
            {

                return null;
            }

            return customer;
        }

        public List<OrderModel> UsersOrders(int customersId)
        {
            List<OrderModel> orders;

            try
            {
                orders = _.Orders.Where(order => order.CustomerIdRef == customersId).ToList();
            }
            catch (Exception)
            {

                return null;
            }

            return orders;
        }
    }
}
