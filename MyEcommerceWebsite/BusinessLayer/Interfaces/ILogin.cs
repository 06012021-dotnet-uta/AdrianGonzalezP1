using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ILogin
    {
        public Task<bool> LoginUserAsync(AccountModel account);
        public Task<CustomerModel> GetUserInfoAsync(AccountModel account);
    }
}
