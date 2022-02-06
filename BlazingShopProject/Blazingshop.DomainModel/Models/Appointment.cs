using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazingshop.DomainModel.Models
{
    public class Appointment
    {
        [Key]
        public int AId { get; set; }
        public string ApplicationUserId { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(30, ErrorMessage = "Name cannot be greater than 30 chars")]
        [MinLength(2, ErrorMessage = "name should contain atleast 3 chars")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter alphabets only")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [StringLength(50)]

        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[7-9]{1}[0-9]{9}$", ErrorMessage = "" +
            "Enter correct phone number starting with 7,8 or 9 and maximum 10 digits")]

        public long CustPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter date and time")]
        public DateTime AppointmentDate { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
