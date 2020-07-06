using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]

    public class PharmacyController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public PharmacyController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]

        public IActionResult Index()
        {
            return View(_UnitOfWork.PharmacyRepository.GetAll());
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Pharmacy Pharmacy = _UnitOfWork.PharmacyRepository.GetByID(id);

            if (Pharmacy == null)
            {
                return NotFound();
            }
            return View(Pharmacy);
        }
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            Pharmacy Pharmacy = new Pharmacy();


            if (id > 0)
            {
                Pharmacy = _UnitOfWork.PharmacyRepository.GetByID(id);
                if (Pharmacy == null)
                {
                    return NotFound();
                }
            }

            return View(Pharmacy);
        }

        // POST: pharmacy/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Pharmacy Pharmacy)
        {
            if (id != Pharmacy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.PharmacyRepository.CreateEntity(Pharmacy);
                        _UnitOfWork.PharmacyRepository.Save();
                    }
                    else
                    {
                        Pharmacy Data = _UnitOfWork.PharmacyRepository.GetByID(id);

                        _Mapper.Map(Pharmacy, Data);

                        _UnitOfWork.PharmacyRepository.UpdateEntity(Data);
                        _UnitOfWork.PharmacyRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.PharmacyRepository.Any(a => a.Id == id))
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
            return View(Pharmacy);
        }
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Pharmacy Pharmacy = _UnitOfWork.PharmacyRepository.GetByID(id);
            if (Pharmacy == null)
            {
                return NotFound();
            }



            return View(Pharmacy);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Pharmacy Pharmacy = _UnitOfWork.PharmacyRepository.GetByID(id);


            _UnitOfWork.PharmacyRepository.DeleteEntity(Pharmacy);


            _UnitOfWork.PharmacyRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
