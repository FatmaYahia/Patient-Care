using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using static PatientCare.Common.DataEnum;


namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class CoronaStatusController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public CoronaStatusController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: CoronaStatus
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.CoronaStatusRepository.GetAll());
        }
        // GET: CoronaStatus/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            CoronaStatus CoronaStatus = _UnitOfWork.CoronaStatusRepository.GetByID(id);

            if (CoronaStatus == null)
            {
                return NotFound();
            }
            return View(CoronaStatus);
        }

        // GET: CoronaStatus/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            CoronaStatus CoronaStatus = new CoronaStatus();


            if (id > 0)
            {
                CoronaStatus = _UnitOfWork.CoronaStatusRepository.GetByID(id);
                if (CoronaStatus == null)
                {
                    return NotFound();
                }
            }

            return View(CoronaStatus);
        }

        // POST: CoronaStatus/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, CoronaStatus CoronaStatus)
        {
            if (id != CoronaStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.CoronaStatusRepository.CreateEntity(CoronaStatus);
                        _UnitOfWork.CoronaStatusRepository.Save();
                    }
                    else
                    {
                        CoronaStatus Data = _UnitOfWork.CoronaStatusRepository.GetByID(id);

                        _Mapper.Map(CoronaStatus, Data);

                        _UnitOfWork.CoronaStatusRepository.UpdateEntity(Data);
                        _UnitOfWork.CoronaStatusRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.CoronaStatusRepository.Any(a => a.Id == id))
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
            return View(CoronaStatus);
        }

        // GET: CoronaStatus/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            CoronaStatus CoronaStatus = _UnitOfWork.CoronaStatusRepository.GetByID(id);
            if (CoronaStatus == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (Enum.IsDefined(typeof(CoronaStatusEnum), id))
            {
                ViewBag.CanDelete = false;
            }

            return View(CoronaStatus);
        }

        // POST: CoronaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            CoronaStatus CoronaStatus = _UnitOfWork.CoronaStatusRepository.GetByID(id);

            if (!Enum.IsDefined(typeof(CoronaStatusEnum), id))
            {
                _UnitOfWork.CoronaStatusRepository.DeleteEntity(CoronaStatus);
            }

            _UnitOfWork.CoronaStatusRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
