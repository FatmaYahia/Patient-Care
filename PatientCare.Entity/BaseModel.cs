using PatientCare.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Created At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = LocalCurrentTime.GetLocalCurrentLocation();


        [DisplayName("Last Modified At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedAt { get; set; } = LocalCurrentTime.GetLocalCurrentLocation();
    }
}
