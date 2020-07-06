using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Chat : BaseModel
    {
        [ForeignKey(nameof(Doctor))]
        [DisplayName("Doctor")]
        public int Fk_Doctor { get; set; }

        [DisplayName("Doctor")]
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        [DisplayName("Patient")]
        public int Fk_Patient { get; set; }

        [DisplayName("Patient")]
        public Patient Patient { get; set; }

        [DisplayName("Messages")]
        public List<Message> Messages { get; set; }
    }
}
