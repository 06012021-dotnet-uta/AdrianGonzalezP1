using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ISignup
    {
        public Task<bool> CreateAccount(AccountModel account);
        public Task<bool> CreateCustomer(CustomerModel newCustomer);
    }
}
