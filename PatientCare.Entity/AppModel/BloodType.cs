using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class BloodType : BaseModel
    {
        [Required]
        [DisplayName("Blood Type")]
        public string Name { get; set; }

        [DisplayName("Patients")]
        public List<Patient> Patients { get; set; }
    }
}
