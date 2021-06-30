using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Customer : ICustomer
    {

        private readonly MyEcommerceDb _;
        public Customer(MyEcommerceDb context)
        {
            _ = context;
        }

        public long LengthOfCustomers()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> SearchCustomer(string Fname, string Lname)
        {
            throw new NotImplementedException();
        }

        public CustomerModel SearchCustomer(string username)
        {
            throw new NotImplementedException();
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
    }
}
