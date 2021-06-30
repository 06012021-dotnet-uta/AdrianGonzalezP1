using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [Table("Product")]
    public class ProductModel : IComparable
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryIdRef { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int Qunatity { get; set; }

        [ForeignKey("CategoryIdRef")]
        public CategoryModel Category { get; set; }

        public ICollection<InventoryModel> Inventories { get; set; }
        public ICollection<OrderModel> Orders { get; set; }

        /// <summary>
        /// The basic construct.
        /// </summary>
        public ProductModel() { }

        /// <summary>
        /// The Product Info returns a string of all the properties of the product object.
        /// </summary>
        /// <returns>Returns a string of all properties</returns>
        public string ProductInfo()
        {
            string product_info = $"\t\t{this.ProductName}\n\tProductId: {this.ProductId}\n\tCategory: {CategoryIdRef}\n\tUnit Price: {this.UnitPrice}\n\tDesciption: {this.Description}";
            return product_info;
        }

        /// <summary>
        /// The CompareTo is used for sorting algorithms.
        /// </summary>
        /// <param name="obj"> A Product Model object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;


            if (obj is ProductModel otherStore)
                return ProductName.CompareTo(otherStore.ProductName);
            else
                throw new ArgumentException("Object is not a ProductModel");
        }
    }
}
