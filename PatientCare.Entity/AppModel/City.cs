using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class City : BaseModel
    {
        [Required]
        [DisplayName("City Name")]
        public string Name { get; set; }

        [DisplayName("Pharmacies")]
        public List<Pharmacy> Pharmacies { get; set; }

        [DisplayName("Hospitals")]
        public List<Hospital> Hospitals { get; set; }
    }
}
