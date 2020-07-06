using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientCare.Entity.AppModel
{
    public class CoronaStatus : BaseModel
    {
        [Required]
        [DisplayName("Corona Status")]
        public string Name { get; set; }

        [DisplayName("Offline Corona Tests")]
        public List<OfflineCoronaTest> OfflineCoronaTests { get; set; }

        [DisplayName("Online Corona Tests")]
        public List<OnlineCoronaTest> OnlineCoronaTests { get; set; }
    }
}
