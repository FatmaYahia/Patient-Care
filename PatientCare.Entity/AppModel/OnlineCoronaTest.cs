using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCare.Entity.AppModel
{
    public class OnlineCoronaTest : BaseModel
    {
        [ForeignKey(nameof(Patient))]
        public int Fk_Patient { get; set; }

        [DisplayName("Patient")]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(CoronaStatus))]
        public int Fk_CoronaStatus { get; set; }

        [DisplayName("Corona Status")]
        public CoronaStatus CoronaStatus { get; set; }
    }
}
