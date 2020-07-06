using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class Message : BaseModel
    {
        [ForeignKey(nameof(Chat))]
        public int Fk_Chat { get; set; }

        [DisplayName("Chat")]
        public Chat Chat { get; set; }

        [DisplayName("Is Viewed")]
        public bool IsViewd { get; set; } = false;

        [DisplayName("Is Doctor")]
        public bool IsDoctor { get; set; }

        [Required]
        [DisplayName("Message Content")]
        public string MessageContent { get; set; }
    }
}
