using PatientCare.Entity.AppModel;
using System.Collections.Generic;

namespace PatientCare.App.ViewModel
{
    public class HomeViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<Specialization> Specializations { get; set; }
    }

}
