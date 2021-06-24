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
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }             // A customer Id which is provided by the database
        
        [ForeignKey("AccountModel")]
        public string Username { get; set; }            // Foriegn key from account
        
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(30)]
        [Display(Name = "First Name", Prompt = "Enter First Name")]
        public string Fname { get; set; }              // First name of the customer

        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(30)]
        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        public string Lname { get; set; }              // Last name of the customer

        // Customer's Address 1
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(40)]
        [Display(Name = "Customer's Address1", Prompt = "Enter Customer's Address1")]
        public string Address1 { get; set; }

        // Customer's Address 2
        [StringLength(40)]
        [Display(Name = "Customer's Address2", Prompt = "Enter Customer's Address2")]
        public string Address2 { get; set; }

        // Customer's City
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(40)]
        [Display(Name = "City", Prompt = "Enter City")]
        public string City { get; set; }

        // Customer's Zipcode
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(40)]
        [Display(Name = "Zipcode", Prompt = "Enter Zipcode")]
        public int Zipcode { get; set; }

        // Customer's State
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(40)]
        [Display(Name = "State", Prompt = "Enter State")]
        public string State { get; set; }

        // Customer's Country
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(40)]
        [Display(Name = "Country", Prompt = "Enter Country")]
        public string Country { get; set; }

        // Customer's Phone Number
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Phone Number", Prompt = "(123) 222-3333")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
         ErrorMessage = "Characters are not allowed.")]
        public string PhoneNumber { get; set; }      // The customers contact info

        // Customer's Email
        [Required(ErrorMessage = "Cannot be empty")]
        [StringLength(30)]
        [Display(Name = "Email", Prompt = "Example@Example.com")]
        public string Email { get; set; }              // The email of customer
        

        public CustomerModel(){ }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>All info about the Client inlcuding Account info</returns>
        //public virtual string CustomerInfo()
        //{
        //    string customer_info = $"\t\tCustomer Information\n\tUsername: {this.Username}\n\tFirst Name: {this.Fname}\n\tLast Name: {this.Lname}\n\tAddress: {this.Address}\n\tContact Number: {this.ContactNumber}\n\tEmail: {this.Email}\n";
        //    return customer_info;
        //}

    }
}
