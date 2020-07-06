using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class DoctorDocument : BaseModel
    {
        [ForeignKey(nameof(Doctor))]
        public int Fk_Doctor { get; set; }

        [DisplayName("Doctor")]
        public Doctor Doctor { get; set; }

        [Required]
        [DisplayName("Document")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImgUrl { get; set; }
    }
}
