using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using PatientCare.Repository;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class SystemViewController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public SystemViewController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        // GET: SystemView
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.SystemViewRepository.GetAll());
        }

        // GET: SystemView/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            SystemView SystemView = _UnitOfWork.SystemViewRepository.GetByID(id);

            if (SystemView == null)
            {
                return NotFound();
            }
            return View(SystemView);
        }

        // GET: SystemView/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            SystemView SystemView = new SystemView();

            if (id > 0)
            {
                SystemView = _UnitOfWork.SystemViewRepository.GetByID(id);
                if (SystemView == null)
                {
                    return NotFound();
                }
            }

            return View(SystemView);
        }

        // POST: SystemView/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, SystemView SystemView)
        {
            if (id != SystemView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.SystemViewRepository.CreateEntity(SystemView);
                        _UnitOfWork.SystemViewRepository.Save();
                    }
                    else
                    {
                        SystemView Data = _UnitOfWork.SystemViewRepository.GetByID(id);

                        _Mapper.Map(SystemView, Data);

                        _UnitOfWork.SystemViewRepository.UpdateEntity(Data);
                        _UnitOfWork.SystemViewRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.SystemViewRepository.Any(a => a.Id == id))
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
            return View(SystemView);
        }

        // GET: SystemView/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            SystemView SystemView = _UnitOfWork.SystemViewRepository.GetByID(id);
            if (SystemView == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (id == (int)SystemViewEnum.SystemView || id == (int)SystemViewEnum.SystemUser
                || id == (int)SystemViewEnum.Home)
            {
                ViewBag.CanDelete = false;
            }

            return View(SystemView);
        }

        // POST: SystemView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            SystemView SystemView = _UnitOfWork.SystemViewRepository.GetByID(id);

            _UnitOfWork.SystemViewRepository.DeleteEntity(SystemView);

            _UnitOfWork.SystemViewRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }

}
