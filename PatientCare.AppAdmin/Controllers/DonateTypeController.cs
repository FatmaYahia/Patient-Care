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

    public class DonateTypeController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public DonateTypeController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: DonateType
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.DonateTypeRepository.GetAll());
        }
        // GET: DonateType/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            DonateType DonateType = _UnitOfWork.DonateTypeRepository.GetByID(id);

            if (DonateType == null)
            {
                return NotFound();
            }
            return View(DonateType);
        }
        // GET: DonateType/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            DonateType DonateType = new DonateType();

            if (id > 0)
            {
                DonateType = _UnitOfWork.DonateTypeRepository.GetByID(id);
                if (DonateType == null)
                {
                    return NotFound();
                }
            }

            return View(DonateType);
        }
        // POST: DonateType/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, DonateType DonateType)
        {
            if (id != DonateType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.DonateTypeRepository.CreateEntity(DonateType);
                        _UnitOfWork.DonateTypeRepository.Save();
                    }
                    else
                    {
                        DonateType Data = _UnitOfWork.DonateTypeRepository.GetByID(id);

                        _Mapper.Map(DonateType, Data);

                        _UnitOfWork.DonateTypeRepository.UpdateEntity(Data);
                        _UnitOfWork.DonateTypeRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.DonateTypeRepository.Any(a => a.Id == id))
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
            return View(DonateType);
        }
        // GET: DonateType/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            DonateType DonateType = _UnitOfWork.DonateTypeRepository.GetByID(id);
            if (DonateType == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (Enum.IsDefined(typeof(DonateTypeEnum), id))
            {
                ViewBag.CanDelete = false;
            }

            return View(DonateType);
        }
        // POST: DonateType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            DonateType DonateType = _UnitOfWork.DonateTypeRepository.GetByID(id);

            if (!Enum.IsDefined(typeof(DonateTypeEnum), id))
            {
                _UnitOfWork.DonateTypeRepository.DeleteEntity(DonateType);
            }

            _UnitOfWork.DonateTypeRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
