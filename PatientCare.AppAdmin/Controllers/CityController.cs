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
    public class CityController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public CityController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: City
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.CityRepository.GetAll());
        }
        // GET: City/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            City City = _UnitOfWork.CityRepository.GetByID(id);

            if (City == null)
            {
                return NotFound();
            }
            return View(City);
        }
        // GET: City/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            City City = new City();

            if (id > 0)
            {
                City = _UnitOfWork.CityRepository.GetByID(id);
                if (City == null)
                {
                    return NotFound();
                }
            }

            return View(City);
        }
        // POST: City/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, City City)
        {
            if (id != City.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _UnitOfWork.CityRepository.CreateEntity(City);
                        _UnitOfWork.CityRepository.Save();
                    }
                    else
                    {
                        City Data = _UnitOfWork.CityRepository.GetByID(id);

                        _Mapper.Map(City, Data);

                        _UnitOfWork.CityRepository.UpdateEntity(Data);
                        _UnitOfWork.CityRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.CityRepository.Any(a => a.Id == id))
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
            return View(City);
        }
        // GET: City/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            City City = _UnitOfWork.CityRepository.GetByID(id);
            if (City == null)
            {
                return NotFound();
            }

            ViewBag.CanDelete = true;


            return View(City);
        }
        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            City City = _UnitOfWork.CityRepository.GetByID(id);

            _UnitOfWork.CityRepository.DeleteEntity(City);

            _UnitOfWork.CityRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
