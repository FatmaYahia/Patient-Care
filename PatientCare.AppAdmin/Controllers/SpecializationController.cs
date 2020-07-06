using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.Common;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class SpecializationController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public SpecializationController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: Specialization
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.SpecializationRepository.GetAll());
        }
        // GET: Specialization/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Specialization Specialization = _UnitOfWork.SpecializationRepository.GetByID(id);

            if (Specialization == null)
            {
                return NotFound();
            }
            return View(Specialization);
        }

        // GET: Specialization/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            Specialization Specialization = new Specialization();


            if (id > 0)
            {
                Specialization = _UnitOfWork.SpecializationRepository.GetByID(id);
                if (Specialization == null)
                {
                    return NotFound();
                }
            }

            return View(Specialization);
        }

        // POST: Specialization/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async System.Threading.Tasks.Task<IActionResult> CreateOrEdit(int id, Specialization Specialization)
        {
            if (id != Specialization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.SpecializationRepository.CreateEntity(Specialization);
                        _UnitOfWork.SpecializationRepository.Save();
                    }
                    else
                    {
                        Specialization Data = _UnitOfWork.SpecializationRepository.GetByID(id);

                        _Mapper.Map(Specialization, Data);

                        _UnitOfWork.SpecializationRepository.UpdateEntity(Data);
                        _UnitOfWork.SpecializationRepository.Save();
                        Specialization = Data;
                    }

                    IFormFile files = HttpContext.Request.Form.Files["ImageFile"];
                    if (files != null)
                    {
                        ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                        string ImgURl = await ImgManager.UploudImageAsync(AppMainData.DomainName, Specialization.Id.ToString(), files, "Uploud/Specialization");

                        if (!string.IsNullOrEmpty(ImgURl))
                        {
                            if (!string.IsNullOrEmpty(Specialization.ImgUrl))
                            {
                                ImgManager.DeleteImage(Specialization.ImgUrl, AppMainData.DomainName);
                            }
                            Specialization.ImgUrl = ImgURl;
                            _UnitOfWork.SpecializationRepository.UpdateEntity(Specialization);
                            _UnitOfWork.SpecializationRepository.Save();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.SpecializationRepository.Any(a => a.Id == id))
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
            return View(Specialization);
        }

        // GET: Specialization/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Specialization Specialization = _UnitOfWork.SpecializationRepository.GetByID(id);
            if (Specialization == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;

            if (Enum.IsDefined(typeof(SpecializationEnum), id))
            {
                ViewBag.CanDelete = false;
            }

            return View(Specialization);
        }

        // POST: Specialization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Specialization Specialization = _UnitOfWork.SpecializationRepository.GetByID(id);

            if (!Enum.IsDefined(typeof(SpecializationEnum), id))
            {
                _UnitOfWork.SpecializationRepository.DeleteEntity(Specialization);
            }

            _UnitOfWork.SpecializationRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
