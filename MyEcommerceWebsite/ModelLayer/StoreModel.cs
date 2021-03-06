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
    /// The main <c>Store</c> class. 
    /// Concatinates all of the fields together of the and returns it as a string 
    /// </summary>
    /// 
    [Table("Store")]
    public class StoreModel: IComparable
    {
        // Store's Key
        [Key]
        public int StoreId { get; set; }

        // Store's Name
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(30)]
        [Display(Name = "Name", Prompt = "Enter Store Name")]
        public string StoreName { get; set; }

        // Store's Address 1
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(40)]
        [Display(Name = "Address 1", Prompt = "Enter Store's Address1")]
        public string Address1 { get; set; }

        // Store's Address 2
        [StringLength(40)]
        [Display(Name = "Address 2", Prompt = "Enter Store's Address2")]
        public string Address2 { get; set; }

        // Store's City
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(40)]
        [Display(Name = "City", Prompt = "Enter City")]
        public string City { get; set; }

        // Store's Zipcode
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(40)]
        [Display(Name = "Zipcode", Prompt = "Enter Zipcode")]
        public string Zipcode { get; set; }

        // Store's State
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(40)]
        [Display(Name = "State", Prompt = "Enter State")]
        public string State { get; set; }

        // Store's Country
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(40)]
        [Display(Name = "Country", Prompt = "Enter Country")]
        public string Country { get; set; }

        // Stores's Phone Number
        [Required(ErrorMessage = "Incorrect Input")]
        [Display(Name = "Phone Number", Prompt = "(123) 222-3333")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
         ErrorMessage = "Characters are not allowed.")]
        public string PhoneNumber { get; set; }

        // Store's Description
        [Required(ErrorMessage = "Incorrect Input")]
        [StringLength(100)]
        [Display(Name = "Description", Prompt = "Enter Store's Description")]
        public string Description { get; set; }


        public ICollection<InventoryModel> Inventories { get; set; }
        public ICollection<OrderModel> Orders { get; set; }

        public StoreModel() { }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;


            if (obj is StoreModel otherStore)
                return StoreName.CompareTo(otherStore.StoreName);
            else
                throw new ArgumentException("Object is not a StoreModel");
        }
    }
}
