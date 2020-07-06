using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class Gender : BaseModel
    {
        [Required]
        [DisplayName("Gender")]
        public string Name { get; set; }

        [DisplayName("Doctors")]
        public List<Doctor> Doctors { get; set; }

        [DisplayName("Patients")]
        public List<Patient> Patients { get; set; }
    }
}
