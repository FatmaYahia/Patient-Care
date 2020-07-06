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
    public class DonationController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public DonationController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.DonationRepository.GetAll());
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Donation donation = _UnitOfWork.DonationRepository.GetByID(id);

            if (donation == null)
            {
                return NotFound();
            }
            return View(donation);
        }

        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (TempData["InvalidId"] != null)
            {
                ViewBag.Error = TempData["InvalidId"];
            }
            Donation donation = new Donation();
            ViewBag.donateType = new SelectList(_UnitOfWork.DonateTypeRepository.GetAll(), "Id", "Name");


            if (id > 0)
            {
                donation = _UnitOfWork.DonationRepository.GetByID(id);
                if (donation == null)
                {
                    return NotFound();
                }
                ViewBag.donateType = new SelectList(_UnitOfWork.DonateTypeRepository.GetAll(), "Id", "Name", donation.Fk_DonateType);

            }
            return View(donation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Donation donation)
        {
            if (id != donation.Id)
            {
                return NotFound();
            }
            if (id == 0)
            {
                if (!_UnitOfWork.PatientRepository.Any(n => n.Phone == donation.EmailOrPhone || n.Email == donation.EmailOrPhone))
                {
                    TempData["InvalidId"] = donation.EmailOrPhone;
                    return RedirectToAction(nameof(CreateOrEdit));
                }
                else
                {
                    donation.Fk_Patient = _UnitOfWork.PatientRepository.GetByPhoneOrEmail(donation.EmailOrPhone).Id;

                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {

                        _UnitOfWork.DonationRepository.CreateEntity(donation);
                        _UnitOfWork.DonationRepository.Save();
                    }
                    else
                    {
                        Donation Data = _UnitOfWork.DonationRepository.GetByID(id);

                        _Mapper.Map(donation, Data);

                        _UnitOfWork.DonationRepository.UpdateEntity(Data);
                        _UnitOfWork.DonationRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.DonationRepository.Any(a => a.Id == id))
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
            ViewBag.donateType = new SelectList(_UnitOfWork.DonateTypeRepository.GetAll(), "Id", "Name");
            return View(donation);
        }

        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Donation donation = _UnitOfWork.DonationRepository.GetByID(id);
            if (donation == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;



            return View(donation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Donation donation = _UnitOfWork.DonationRepository.GetByID(id);
            _UnitOfWork.DonationRepository.DeleteEntity(donation);
            _UnitOfWork.DonationRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
