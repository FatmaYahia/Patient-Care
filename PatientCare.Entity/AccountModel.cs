using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class AccountModel : BaseModel
    {
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }


        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [MinLength(6)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [ForeignKey(nameof(Gender))]
        [DisplayName("Gender")]
        public int Fk_Gender { get; set; }

        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [NotMapped]
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
