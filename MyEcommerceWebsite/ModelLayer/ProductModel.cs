using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ProductModel : CategoryModel, IComparable
    {
        private decimal _unitPrice;
        private string _productName;

        public int ProductId { get; set; }
        public string Description { get; set; }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set 
            { 
                if(value >= 0.00m)
                    _unitPrice = value; 
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set 
            { 
                if(value.Length >= 1 && value.Length <= 30)
                    _productName = value; 
            }
        }
        
        /// <summary>
        /// The basic construct.
        /// </summary>
        public ProductModel() : base() { }


        /// <summary>
        /// Responsible for initializing the prodocut's state when instantiated
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="Description"></param>
        /// <param name="categoryObj"></param>
        public ProductModel(string ProductName, decimal UnitPrice, string Description, CategoryModel categoryObj) : base(categoryObj)
        {
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Description = Description;
        }

        /// <summary>
        /// The Product Info returns a string of all the properties of the product object.
        /// </summary>
        /// <returns>Returns a string of all properties</returns>
        public string ProductInfo()
        {
            string product_info = $"\t\t{this._productName}\n\tProductId: {this.ProductId}\n\tCategory: {base.CategoryName}\n\tUnit Price: {this._unitPrice}\n\tDesciption: {this.Description}";
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
