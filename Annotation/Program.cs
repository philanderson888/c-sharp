using System;
using System.ComponentModel.DataAnnotations;

namespace Annotation
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }


    }

    class User
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(7)]
        [StringLength(40)]
        public string Username { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Url]
        public string WebAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Log Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LogDate { get; set; } = DateTime.Today;
    }
}
