using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICustomer
    {
        List<CustomerModel> SearchCustomer(string Fname, string Lname);
        CustomerModel SearchCustomer(string username);
        CustomerModel SearchCustomer(int customerId);
        long LengthOfCustomers();
    }
}
