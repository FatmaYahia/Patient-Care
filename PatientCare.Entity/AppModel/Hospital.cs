using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Hospital : BaseModel
    {
        [Required]
        [DisplayName("Hospital Name")]
        public string Name { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Corona Available Beds")]
        public int AvailableBeds { get; set; } = 0;

        [DisplayName("Location Latitude")]
        public double Latitude { get; set; } = 0;

        [DisplayName("Location Longitude")]
        public double Longitude { get; set; } = 0;

        [ForeignKey(nameof(City))]
        [DisplayName("City")]
        public int Fk_City { get; set; }

        [DisplayName("City")]
        public City City { get; set; }
    }
}
