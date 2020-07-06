using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    public class OnlineCoronaTestController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public OnlineCoronaTestController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.OnlineCoronaTestRepository.GetAll());
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            OnlineCoronaTest OnlineCoronaTest = _UnitOfWork.OnlineCoronaTestRepository.GetByID(id);

            if (OnlineCoronaTest == null)
            {
                return NotFound();
            }
            return View(OnlineCoronaTest);
        }
    }
}
