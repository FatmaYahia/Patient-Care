using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class Specialization : BaseModel
    {
        [Required]
        [DisplayName("Specialization Name")]
        public string Name { get; set; }

        [DisplayName("Doctors")]
        public List<Doctor> Doctors { get; set; }

        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImgUrl { get; set; }
    }
}
