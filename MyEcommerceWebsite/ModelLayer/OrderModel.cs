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
    /// This class represents what an Order contains
    /// </summary>
    /// 

    [Table("Order")]
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerIdRef { get; set; }
        public int StoreIdRef { get; set; }
        public int ProductIdRef { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Display(Prompt = "The Amount Taking")]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [ForeignKey("CustomerIdRef")]
        public virtual CustomerModel Customer { get; set; }
        [ForeignKey("ProductIdRef")]
        public virtual ProductModel Product { get; set; }
        [ForeignKey("StoreIdRef")]
        public virtual StoreModel Store { get; set; }


        /// <summary>
        /// The OrderInfo returns back all the properties of the object in the form of a string.
        /// </summary>
        /// <returns>Returns a string of all of the properties of this object</returns>
        public string OrderInfo()
        {
            string oderInfo = $"\n\tCustomer id: {this.CustomerIdRef}\n\tStoreId: {this.StoreIdRef}\n\tProductId: {this.ProductIdRef}\n\tUnit Price: {this.UnitPrice}\n\tQuantity: {this.Quantity}\n\tTotal Amount: {this.TotalAmount}\n\tOrder Date: {this.OrderDate}";
            return oderInfo;
        }
    }
}
