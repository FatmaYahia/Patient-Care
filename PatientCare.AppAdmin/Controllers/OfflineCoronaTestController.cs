using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class OfflineCoronaTestController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public OfflineCoronaTestController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.OfflineCoronaTestRepository.GetAll());
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            OfflineCoronaTest test = _UnitOfWork.OfflineCoronaTestRepository.GetByID(id);

            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (TempData["InvalidId"] != null)
            {
                ViewBag.Error = TempData["InvalidId"];
            }
            OfflineCoronaTest test = new OfflineCoronaTest();
            ViewBag.coronaStatus = new SelectList(_UnitOfWork.CoronaStatusRepository.getOfflineStatus(), "Id", "Name");
            if (id > 0)
            {
                test = _UnitOfWork.OfflineCoronaTestRepository.GetByID(id);
                if (test == null)
                {
                    return NotFound();
                }
                ViewBag.coronaStatus = new SelectList(_UnitOfWork.CoronaStatusRepository.getOfflineStatus(), "Id", "Name", test.Fk_CoronaStatus);
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, OfflineCoronaTest test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }
            if (id == 0)
            {
                if (!_UnitOfWork.PatientRepository.Any(n => n.Phone == test.EmailOrPhone || n.Email == test.EmailOrPhone))
                {
                    TempData["InvalidId"] = test.EmailOrPhone;
                    return RedirectToAction(nameof(CreateOrEdit));
                }
                else
                {
                    test.Fk_Patient = _UnitOfWork.PatientRepository.GetByPhoneOrEmail(test.EmailOrPhone).Id;

                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.OfflineCoronaTestRepository.CreateEntity(test);
                        _UnitOfWork.OfflineCoronaTestRepository.Save();
                    }
                    else
                    {
                        OfflineCoronaTest Data = _UnitOfWork.OfflineCoronaTestRepository.GetByID(id);

                        _Mapper.Map(test, Data);

                        _UnitOfWork.OfflineCoronaTestRepository.UpdateEntity(Data);
                        _UnitOfWork.OfflineCoronaTestRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.OfflineCoronaTestRepository.Any(a => a.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.coronaStatus = new SelectList(_UnitOfWork.CoronaStatusRepository.getOfflineStatus(), "Id", "Name");

            return View(test);
        }

        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            OfflineCoronaTest test = _UnitOfWork.OfflineCoronaTestRepository.GetByID(id);
            if (test == null)
            {
                return NotFound();
            }
            ViewBag.CanDelete = true;
            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            OfflineCoronaTest test = _UnitOfWork.OfflineCoronaTestRepository.GetByID(id);
            _UnitOfWork.OfflineCoronaTestRepository.DeleteEntity(test);
            _UnitOfWork.OfflineCoronaTestRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
