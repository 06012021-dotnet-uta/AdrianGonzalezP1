using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace BusinessLayer
{
    public class Signup: ISignup
    {
        private readonly MyEcommerceDb _;
        public Signup(MyEcommerceDb context)
        {
            _ = context;
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<bool> CreateAccount(AccountModel account)
        {
            await _.Accounts.AddAsync(account);
            try
            {
                await _.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine($"Error - Could not create Account:\n{account.AccountInfo()}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates a new Customer 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        public async Task<bool> CreateCustomer(CustomerModel newCustomer)
        {
            await _.Customers.AddAsync(newCustomer);
            try
            {
                await _.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine($"Error - Could not create customer:\n{newCustomer.CustomerInfo()}\n");
                Console.WriteLine($"Error Code => {e.InnerException}");
                return false;
            }

            return true;
        }
    }
}
