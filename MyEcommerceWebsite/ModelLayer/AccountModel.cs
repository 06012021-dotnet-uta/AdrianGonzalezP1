using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// The Account class is responsible for keeping the Customers Username and password
    /// </summary>
    public class AccountModel
    {
        public string Username { get; set; } // User Password
        public string Password { get; set; }

        public AccountModel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public AccountModel(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        /// <summary>
        /// The Account Info Method is responsible for returning the Account's username and password
        /// </summary>
        /// <returns></returns>
        public string AccountInfo()
        {
            string account_info = $"\nUsername:{this.Username}\nPassword: {this.Password}\n";
            return account_info;
        }

    }
}
