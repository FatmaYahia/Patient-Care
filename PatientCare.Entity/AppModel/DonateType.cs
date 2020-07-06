using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class DonateType : BaseModel
    {
        [Required]
        [DisplayName("Donate Type")]
        public string Name { get; set; }

        [DisplayName("Donations")]
        public List<Donation> Donations { get; set; }
    }
}
