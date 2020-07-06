using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientCare.AppAdmin.Filters;
using PatientCare.AppAdmin.Models;
using PatientCare.AppAdmin.ViewModel;
using PatientCare.DAL;
using System.Diagnostics;
using System.Linq;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _DBContext;

        public HomeController(ILogger<HomeController> logger, DataContext DBContext)
        {
            _logger = logger;
            _DBContext = DBContext;
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(new HomeViewModel
            {
                Specialization = _DBContext.Specializations.Count(),
                Patient = _DBContext.Patients.Count(),
                Donation = _DBContext.Donations.Count(),
                OfflineCoronaTest = _DBContext.OfflineCoronaTests.Count(),
                Doctor = _DBContext.Doctors.Count(),
                Chat = _DBContext.Chats.Count(),
                Hospital = _DBContext.Hospitals.Count(),
                Pharmacy = _DBContext.Pharmacies.Count(),
                SystemUser = _DBContext.SystemUser.Count()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
