using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class PatientDocument : BaseModel
    {
        [ForeignKey(nameof(Patient))]
        public int Fk_Patient { get; set; }

        [DisplayName("Patient")]
        public Patient Patient { get; set; }

        [Required]
        [DisplayName("Document")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImgUrl { get; set; }
    }
}
