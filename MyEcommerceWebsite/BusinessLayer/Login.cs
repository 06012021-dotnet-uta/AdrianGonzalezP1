using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using RepositoryLayer;

namespace BusinessLayer
{
    public class Login: ILogin
    {
        private readonly MyEcommerceDb _;
        public Login(MyEcommerceDb context)
        {
            _ = context;
        }

        /// <summary>
        /// Checks if user exists!
        /// </summary>
        /// <param name="account"></param>
        /// <returns>An exisitng account </returns>
        public async Task<bool> LoginUserAsync(AccountModel account)
        {

            bool doesExists;
            try
            {
               doesExists = await Task.FromResult(_.Accounts.AsEnumerable().Contains(account, new AccountComparer()));

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error - An error accured {e.InnerException}");
                return false;
            }

            return doesExists;
        }

        /// <summary>
        /// Grabs user Customers information
        /// </summary>
        /// <param name="account"></param>
        /// <returns>The customers account</returns>
        public async Task<CustomerModel> GetUserInfoAsync(AccountModel account)
        {
            CustomerModel customer;
            try
            {
                customer = await Task.FromResult(_.Customers.SingleOrDefault(c => c.UsernameRef == account.Username));

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error - Could not retrieve Customer => {e.InnerException}");
                return null;
            }

            return customer;
        }
    }
}
