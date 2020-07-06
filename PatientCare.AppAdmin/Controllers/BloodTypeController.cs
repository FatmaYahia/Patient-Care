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
    public class BloodTypeController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public BloodTypeController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: BloodType
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.BloodTypeRepository.GetAll());
        }
        // GET: BloodType/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            BloodType BloodType = _UnitOfWork.BloodTypeRepository.GetByID(id);

            if (BloodType == null)
            {
                return NotFound();
            }
            return View(BloodType);
        }
        // GET: BloodType/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            BloodType BloodType = new BloodType();

            if (id > 0)
            {
                BloodType = _UnitOfWork.BloodTypeRepository.GetByID(id);
                if (BloodType == null)
                {
                    return NotFound();
                }
            }

            return View(BloodType);
        }
        // POST: BloodType/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, BloodType BloodType)
        {
            if (id != BloodType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.BloodTypeRepository.CreateEntity(BloodType);
                        _UnitOfWork.BloodTypeRepository.Save();
                    }
                    else
                    {
                        BloodType Data = _UnitOfWork.BloodTypeRepository.GetByID(id);

                        _Mapper.Map(BloodType, Data);

                        _UnitOfWork.BloodTypeRepository.UpdateEntity(Data);
                        _UnitOfWork.BloodTypeRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.BloodTypeRepository.Any(a => a.Id == id))
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
            return View(BloodType);
        }
        // GET: BloodType/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            BloodType BloodType = _UnitOfWork.BloodTypeRepository.GetByID(id);
            if (BloodType == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (Enum.IsDefined(typeof(BloodTypeEnum), id))
            {
                ViewBag.CanDelete = false;
            }

            return View(BloodType);
        }
        // POST: BloodType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            BloodType BloodType = _UnitOfWork.BloodTypeRepository.GetByID(id);

            if (!Enum.IsDefined(typeof(BloodTypeEnum), id))
            {
                _UnitOfWork.BloodTypeRepository.DeleteEntity(BloodType);
            }

            _UnitOfWork.BloodTypeRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
