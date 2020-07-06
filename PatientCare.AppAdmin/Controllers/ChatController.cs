using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Repository;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]

    public class ChatController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public ChatController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]

        public IActionResult Index()
        {
            return View(_UnitOfWork.ChatRepository.GetAll());
        }
    }
}
