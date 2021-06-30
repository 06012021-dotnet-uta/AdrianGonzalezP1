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
    /// The main <c>Customer</c> class. 
    /// Contains detail information about a customer.    
    /// </summary>
    [Table("Customer")]
    public class CustomerModel
    {
        // A CustomerID
        [Key]
        public int CustomerId { get; set; }

        // Username Foreign Key from account
        public string UsernameRef { get; set; }

        // First name of the customer
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(30)]
        [Display(Name = "First Name", Prompt = "Enter First Name")]
        public string Fname { get; set; }

        // Last name of the customer
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(30)]
        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        public string Lname { get; set; }

        // Customer's Address 1
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(40)]
        [Display(Name = "Address1", Prompt = "Enter Address1")]
        public string Address1 { get; set; }

        // Customer's Address 2
        [StringLength(40)]
        [Display(Name = "Address2", Prompt = "Enter Address2")]
        public string Address2 { get; set; }

        // Customer's City
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(40)]
        [Display(Name = "City", Prompt = "Enter City")]
        public string City { get; set; }

        // Customer's Zipcode
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(5)]
        [Display(Name = "Zipcode", Prompt = "Enter Zipcode")]
        public string Zipcode { get; set; }

        // Customer's State
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(40)]
        [Display(Name = "State", Prompt = "Enter State")]
        public string State { get; set; }

        // Customer's Country
        [Required(ErrorMessage = "The value is invalid.")]
        [StringLength(40)]
        [Display(Name = "Country", Prompt = "Enter Country")]
        public string Country { get; set; }

        // Customer's Phone Number
        [Required(ErrorMessage = "The value is invalid.")]
        [Display(Name = "Phone Number", Prompt = "(123) 222-3333")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
         ErrorMessage = "Characters are not allowed.")]
        public string PhoneNumber { get; set; } 

        // Customer's Email
        [Required(ErrorMessage = "The value is invalid.")]
        [EmailAddress]
        [StringLength(30)]
        [Display(Name = "Email", Prompt = "Example@Example.com")]
        public string Email { get; set; }


       [ForeignKey("UsernameRef")]
       public AccountModel Account { get; set; }

       public ICollection<OrderModel> Orders { get; set; }

        public CustomerModel(){ }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>All info about the Client inlcuding Account info</returns>
        public virtual string CustomerInfo()
        {
            string customer_info = $"\t\tCustomer Information\n\tUsername: {this.UsernameRef}\n\tFirst Name: {this.Fname}\n\tLast Name: {this.Lname}\n\tAddress: {this.Address1}\n\tCity: {this.City}\n\tState: {this.State}\n\tZipcode: {this.Zipcode}\n\tContact Number: {this.PhoneNumber}\n\tEmail: {this.Email}\n";
            return customer_info;
        }

    }
}
