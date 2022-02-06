using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazingshop.DomainModel.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [MinLength(2, ErrorMessage = "name should contain atleast 2 chars")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter alphabets only")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please specify color")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter alphabets only")]
        public string ShadeColor { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [Range(0, 500, ErrorMessage = "Price can be between 0 and 500")]
        public double Price { get; set; }
        public byte[] files { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
