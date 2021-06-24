using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class InventoryModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public InventoryModel() { }
        public InventoryModel(int StoreId, int ProductId, int Quantity)
        {
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }
    }
}
