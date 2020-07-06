using PatientCare.Entity.AppModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AuthModel
{
    public class SystemUserPermission : BaseModel
    {
        [ForeignKey(nameof(AccessLevel))]
        public int Fk_AccessLevel { get; set; }

        [DisplayName("Access Level")]
        public AccessLevel AccessLevel { get; set; }

        [ForeignKey(nameof(SystemUser))]
        public int Fk_SystemUser { get; set; }

        [DisplayName("System User")]
        public SystemUser SystemUser { get; set; }

        [ForeignKey(nameof(SystemView))]
        public int Fk_SystemView { get; set; }

        [DisplayName("System View")]
        public SystemView SystemView { get; set; }
    }
}
