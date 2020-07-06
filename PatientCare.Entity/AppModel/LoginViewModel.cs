using PatientCare.Entity.AppModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.AppAdmin.Models
{
    public class LoginViewModel : BaseModel
    {

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
