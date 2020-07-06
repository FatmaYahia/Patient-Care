using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AuthModel
{
    public class SystemUser : BaseModel
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


        [Required]
        [DisplayName("Full name")]
        public string FullName { get; set; }


        [Required]
        [DisplayName("Job Title")]
        public string JopTitle { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        public List<SystemUserPermission> SystemUserPermission { get; set; }


    }
}
