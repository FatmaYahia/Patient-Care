using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Doctor : AccountModel
    {
        [DisplayName("Is Online")]
        public bool IsOnline { get; set; } = false;

        [DisplayName("Is Verified")]
        public bool IsVerified { get; set; } = false;

        [ForeignKey(nameof(Specialization))]
        public int Fk_Specialization { get; set; }

        [DisplayName("Specialization")]
        public Specialization Specialization { get; set; }

        [DisplayName("Doctor Agenda")]
        public List<Agenda> Agenda { get; set; }

        [DisplayName("Doctor Chats")]
        public List<Chat> Chats { get; set; }

        [DisplayName("Doctor Documents")]
        public List<DoctorDocument> DoctorDocuments { get; set; }

        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImgUrl { get; set; }
    }
}
