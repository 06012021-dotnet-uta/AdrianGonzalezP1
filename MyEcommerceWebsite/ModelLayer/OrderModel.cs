using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// This class represents what an Order contains
    /// </summary>
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderModel() { }

        /// <summary>
        /// This constructor is responsible for initializing the state of the Order object
        /// </summary>
        /// <param name="CusotmerId"></param>
        /// <param name="StoreId"></param>
        /// <param name="ProductId"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="Quantity"></param>
        /// <param name="TotalAmount"></param>
        /// <param name="OrderDate"></param>
        public OrderModel(int CusotmerId, int StoreId, int ProductId, decimal UnitPrice, int Quantity, decimal TotalAmount, DateTime OrderDate)
        {
            this.CustomerId = CusotmerId;
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.TotalAmount = TotalAmount;
            this.OrderDate = OrderDate;
        }

        /// <summary>
        /// The OrderInfo returns back all the properties of the object in the form of a string.
        /// </summary>
        /// <returns>Returns a string of all of the properties of this object</returns>
        public string OrderInfo()
        {
            string oderInfo = $"\n\tCustomer id: {this.CustomerId}\n\tStoreId: {this.StoreId}\n\tProductId: {this.ProductId}\n\tUnit Price: {this.UnitPrice}\n\tQuantity: {this.Quantity}\n\tTotal Amount: {this.TotalAmount}\n\tOrder Date: {this.OrderDate}";
            return oderInfo;
        }
    }
}
