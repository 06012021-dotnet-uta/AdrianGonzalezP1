using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public CategoryModel() { }

        /// <summary>
        /// This Constructor is reposible for initializing the state of the object
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="CategoryName"></param>
        public CategoryModel(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
        }

        /// <summary>
        /// This Constructor is mainley used for whenever the product is being initialized
        /// </summary>
        /// <param name="categoryObj"></param>
        public CategoryModel(CategoryModel categoryObj)
        {
            this.CategoryId = categoryObj.CategoryId;
            this.CategoryName = categoryObj.CategoryName;
        }
    }
}
