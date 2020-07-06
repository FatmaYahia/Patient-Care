using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AuthModel
{
    public class AccessLevel : BaseModel
    {
        [Required(ErrorMessage = "Please fill this field")]
        [DisplayName("Access Level Name")]
        public string Name { get; set; }

        public List<SystemUserPermission> SystemUserPermission { get; set; }

    }
}
