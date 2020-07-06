using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Agenda : BaseModel
    {
        [ForeignKey(nameof(Doctor))]
        public int Fk_Doctor { get; set; }

        [DisplayName("Doctor")]
        public Doctor Doctor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Time From")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{hh:mm tt}", ApplyFormatInEditMode = true)]
        public TimeSpan TimeFrom { get; set; }

        [DisplayName("Time To")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{hh:mm tt}", ApplyFormatInEditMode = true)]
        public TimeSpan TimeTo { get; set; }
        [NotMapped]
        public int? TimeFromHour { get; set; }
        [NotMapped]
        public int? TimeFromMinute { get; set; }
        [NotMapped]
        public int? TimeToHour { get; set; }
        [NotMapped]
        public int? TimeToMinute { get; set; }

        [NotMapped]
        public string EmailOrPhone { get; set; }

    }
}
