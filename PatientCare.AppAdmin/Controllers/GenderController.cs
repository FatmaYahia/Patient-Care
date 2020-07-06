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
    public class GenderController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public GenderController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: Gender
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.GenderRepository.GetAll());
        }

        // GET: Gender/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Gender Gender = _UnitOfWork.GenderRepository.GetByID(id);

            if (Gender == null)
            {
                return NotFound();
            }
            return View(Gender);
        }

        // GET: Gender/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            Gender Gender = new Gender();


            if (id > 0)
            {
                Gender = _UnitOfWork.GenderRepository.GetByID(id);
                if (Gender == null)
                {
                    return NotFound();
                }
            }

            return View(Gender);
        }

        // POST: Gender/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Gender Gender)
        {
            if (id != Gender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.GenderRepository.CreateEntity(Gender);
                        _UnitOfWork.GenderRepository.Save();
                    }
                    else
                    {
                        Gender Data = _UnitOfWork.GenderRepository.GetByID(id);

                        _Mapper.Map(Gender, Data);

                        _UnitOfWork.GenderRepository.UpdateEntity(Data);
                        _UnitOfWork.GenderRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.GenderRepository.Any(a => a.Id == id))
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
            return View(Gender);
        }

        // GET: Gender/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Gender Gender = _UnitOfWork.GenderRepository.GetByID(id);
            if (Gender == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (Enum.IsDefined(typeof(GenderEnum), id))
            {
                ViewBag.CanDelete = false;
            }

            return View(Gender);
        }

        // POST: Gender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Gender Gender = _UnitOfWork.GenderRepository.GetByID(id);

            if (!Enum.IsDefined(typeof(GenderEnum), id))
            {
                _UnitOfWork.GenderRepository.DeleteEntity(Gender);
            }

            _UnitOfWork.GenderRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
