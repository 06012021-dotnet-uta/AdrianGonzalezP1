using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [Table("Inventory")]
    public class InventoryModel
    {
        [Key]
        public int InventoryId { get; set; }
        public int StoreIdRef { get; set; }
        public int ProductIdRef { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductIdRef")]
        public ProductModel Product { get; set; }
        [ForeignKey("StoreIdRef")]
        public StoreModel Store { get; set; }

        public InventoryModel() { }
    }
}
