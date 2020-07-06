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

    public class HospitalController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public HospitalController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;

        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]

        public IActionResult Index()
        {
            return View(_UnitOfWork.HospitalRepository.GetAll());
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Hospital Hospital = _UnitOfWork.HospitalRepository.GetByID(id);

            if (Hospital == null)
            {
                return NotFound();
            }
            return View(Hospital);
        }

        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            Hospital Hospital = new Hospital();


            if (id > 0)
            {
                Hospital = _UnitOfWork.HospitalRepository.GetByID(id);
                if (Hospital == null)
                {
                    return NotFound();
                }
            }

            return View(Hospital);
        }

        // POST: Hospital/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Hospital Hospital)
        {
            if (id != Hospital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.HospitalRepository.CreateEntity(Hospital);
                        _UnitOfWork.HospitalRepository.Save();
                    }
                    else
                    {
                        Hospital Data = _UnitOfWork.HospitalRepository.GetByID(id);

                        _Mapper.Map(Hospital, Data);

                        _UnitOfWork.HospitalRepository.UpdateEntity(Data);
                        _UnitOfWork.HospitalRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.HospitalRepository.Any(a => a.Id == id))
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
            return View(Hospital);
        }
        // GET: Hospital/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Hospital Hospital = _UnitOfWork.HospitalRepository.GetByID(id);
            if (Hospital == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;



            return View(Hospital);
        }

        // POST: Hospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Hospital Hospital = _UnitOfWork.HospitalRepository.GetByID(id);


            _UnitOfWork.HospitalRepository.DeleteEntity(Hospital);


            _UnitOfWork.HospitalRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

