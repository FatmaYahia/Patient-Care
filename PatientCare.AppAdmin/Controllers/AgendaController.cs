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
    public class AgendaController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public AgendaController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }
        // GET: Agenda
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.AgendaRepository.GetAll());
        }
        // GET: Agenda/Details/5
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Agenda Agenda = _UnitOfWork.AgendaRepository.GetByID(id);

            if (Agenda == null)
            {
                return NotFound();
            }
            return View(Agenda);
        }

        // GET: Agenda/CreateOrEdit/5
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            Agenda Agenda = new Agenda();

            if (id > 0)
            {
                Agenda = _UnitOfWork.AgendaRepository.GetByID(id);
                if (Agenda == null)
                {
                    return NotFound();
                }
            }
            return View(Agenda);
        }

        // POST: Agenda/CreateOrEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Agenda Agenda)
        {
            if (id != Agenda.Id)
            {
                return NotFound();
            }
            if (id == 0)
            {
                if (!_UnitOfWork.DoctorRepository.Any(n => n.Phone == Agenda.EmailOrPhone || n.Email == Agenda.EmailOrPhone))
                {
                    TempData["InvalidId"] = Agenda.EmailOrPhone;
                    return RedirectToAction(nameof(CreateOrEdit));
                }
                else
                {
                    Agenda.Fk_Doctor = _UnitOfWork.DoctorRepository.GetByPhoneOrEmail(Agenda.EmailOrPhone).Id;

                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        Agenda.TimeFrom = new TimeSpan((int)Agenda.TimeFromHour, (int)Agenda.TimeToMinute, 0);
                        Agenda.TimeTo = new TimeSpan((int)Agenda.TimeToHour, (int)Agenda.TimeToMinute, 0);
                        _UnitOfWork.AgendaRepository.CreateEntity(Agenda);
                        _UnitOfWork.AgendaRepository.Save();
                    }
                    else
                    {
                        Agenda.TimeFrom = new TimeSpan((int)Agenda.TimeFromHour, (int)Agenda.TimeToMinute, 0);
                        Agenda.TimeTo = new TimeSpan((int)Agenda.TimeToHour, (int)Agenda.TimeToHour, 0);
                        Agenda Data = _UnitOfWork.AgendaRepository.GetByID(id);

                        _Mapper.Map(Agenda, Data);

                        _UnitOfWork.AgendaRepository.UpdateEntity(Data);
                        _UnitOfWork.AgendaRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.AgendaRepository.Any(a => a.Id == id))
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
            return View(Agenda);
        }

        // GET: Agenda/Delete/5
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Agenda Agenda = _UnitOfWork.AgendaRepository.GetByID(id);
            if (Agenda == null)
            {
                return NotFound();
            }
            return View(Agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Agenda Agenda = _UnitOfWork.AgendaRepository.GetByID(id);

            _UnitOfWork.AgendaRepository.DeleteEntity(Agenda);
            _UnitOfWork.AgendaRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
