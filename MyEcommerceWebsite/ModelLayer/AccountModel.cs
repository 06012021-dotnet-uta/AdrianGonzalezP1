using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key()]
        [StringLength(15)]
        [Display(Name = "Username", Prompt = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [StringLength(16)]
        [Display(Name = "Password", Prompt = "Enter Password")]
        public string Password { get; set; }

        public ICollection<CustomerModel> Customers { get; set; }

        public AccountModel() { }

        /// <summary>
        /// The Account Info Method is responsible for returning the Account's username and password
        /// </summary>
        /// <returns></returns>
        public virtual string AccountInfo()
        {
            string account_info = $"\nUsername:{this.Username}\nPassword: {this.Password}\n";
            return account_info;
        }

    }
}
