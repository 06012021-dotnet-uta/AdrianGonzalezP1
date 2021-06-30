using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// The Account class is responsible for keeping the Customers Username and password
    /// </summary>

    [Table("Account")]
    public class AccountModel
    {

        [Key]
        [Required(ErrorMessage = "The value is invalid.")]
        [Display(Name = "Username", Prompt = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The value is invalid.")]
        [DataType(DataType.Password)]
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
