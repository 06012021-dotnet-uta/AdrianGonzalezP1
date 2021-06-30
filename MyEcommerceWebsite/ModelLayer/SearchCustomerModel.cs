using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class SearchCustomerModel
    {
        [Required(ErrorMessage ="Invalid Input")]
        [Display(Name ="First Name", Prompt = "Enter First Name")]
        public string Fname {get; set;}
        [Required(ErrorMessage = "Invalid Input")]
        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        public string Lname { get; set; }
    }
}
