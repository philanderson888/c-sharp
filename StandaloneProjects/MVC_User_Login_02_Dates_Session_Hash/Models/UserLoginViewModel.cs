using System.ComponentModel.DataAnnotations;

namespace MVC_User_Login.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50,ErrorMessage ="Username must be less than 50 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(20,ErrorMessage = "Password must be between 8 and 20 characters")]
        public string Password { get; set; }
    }
}