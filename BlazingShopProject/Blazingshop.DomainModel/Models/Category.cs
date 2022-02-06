using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazingshop.DomainModel.Models
{
    public class Category
    {
        [Key]
        public int CId { get; set; }

        [Required(ErrorMessage = "Please enter Category Name")]
        //[MinLength(2, ErrorMessage = "Category name should contain atleast 2 chars")]
        //[RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Please enter alphabets only")]

        public string CategoryName { get; set; }
    }
}
