using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Patient : AccountModel
    {

        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Location Latitude")]
        public double Latitude { get; set; } = 0;

        [DisplayName("Location Longitude")]
        public double Longitude { get; set; } = 0;
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Value")]
        [DisplayName("Weight in KG")]
        public int Weight { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Value")]
        [DisplayName("Height in CM")]
        public int Height { get; set; }

        [DisplayName("Is Pregnant")]
        public bool IsPregnant { get; set; } = false;

        [DisplayName("Cronic Diseases")]
        [DataType(DataType.MultilineText)]
        public string CronicDiseases { get; set; }

        [DisplayName("Is Verified")]
        public bool IsVerified { get; set; } = true;// to block someone if we want

        [ForeignKey(nameof(BloodType))]
        [DisplayName("Blood Type")]
        public int Fk_BloodType { get; set; }

        [DisplayName("Blood Type")]
        public BloodType BloodType { get; set; }

        [DisplayName("Patient Documents")]
        public List<PatientDocument> PatientDocuments { get; set; }

        [DisplayName("Patient Chats")]
        public List<Chat> Chats { get; set; }

        [DisplayName("Donations")]
        public List<Donation> Donations { get; set; }

        [DisplayName("Offline Corona Tests")]
        public List<OfflineCoronaTest> OfflineCoronaTests { get; set; }

        [DisplayName("Online Corona Tests")]
        public List<OnlineCoronaTest> OnlineCoronaTests { get; set; }
    }
}
