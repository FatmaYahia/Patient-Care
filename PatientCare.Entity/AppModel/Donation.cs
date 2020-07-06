using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Donation : BaseModel
    {
        [ForeignKey(nameof(Patient))]
        public int Fk_Patient { get; set; }

        [DisplayName("Patient ID")]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(DonateType))]
        public int Fk_DonateType { get; set; }

        [DisplayName("Donate Type")]
        public DonateType DonateType { get; set; }

        [NotMapped]
        public string EmailOrPhone { get; set; }
    }
}
