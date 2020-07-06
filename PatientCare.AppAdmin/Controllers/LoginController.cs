using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using PatientCare.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PatientCare.AppAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext DataBase;
        private readonly UnitOfWork UnitOfWork;
        private readonly IMapper IMapper;
        private readonly ISession Session;

        public LoginController(DataContext DataBase, UnitOfWork UnitOfWork, IMapper IMapper, IHttpContextAccessor HttpContextAccessor)
        {
            this.DataBase = DataBase;
            this.UnitOfWork = UnitOfWork;
            this.IMapper = IMapper;
            Session = HttpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SystemUser systemUser)
        {
            try
            {
                if (UnitOfWork.SystemUserRepository.UserExists(systemUser.Email, systemUser.Password))
                {
                    systemUser = UnitOfWork.SystemUserRepository.GetByEmail(systemUser.Email);

                    Session.SetString("Email", systemUser.Email);
                    Session.SetString("FullName", systemUser.FullName);
                    Session.SetString("JopTitle", systemUser.JopTitle);

                    SetUserViews(systemUser.Email);

                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewData["Error"] = "Email or Password Are Wrong, Or Acount Is Deactive!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfWork.SystemUserRepository.UserExists(systemUser.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(systemUser);
        }
        public void SetUserViews(string Email)
        {
            List<SystemView> SystemViews = UnitOfWork.SystemViewRepository.GetSystemViews(Email);
            if (SystemViews.Any())
            {
                List<string> Views = SystemViews.Select(a => a.Name).ToList();
                foreach (string view in Views)
                {
                    Session.SetString(view, view);
                }
            }
        }

        public IActionResult Edit()
        {
            string Email = Session.GetString("Email");

            if (Email == null)
            {
                return NotFound();
            }
            return View(UnitOfWork.SystemUserRepository.GetByEmail(Email));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SystemUser systemUser)
        {
            try
            {
                string Email = Session.GetString("Email");
                if (Email == null)
                {
                    return NotFound();
                }

                SystemUser Data = UnitOfWork.SystemUserRepository.GetByEmail(Email);
                IMapper.Map(systemUser, Data);

                UnitOfWork.SystemUserRepository.UpdateEntity(Data);
                UnitOfWork.SystemUserRepository.Save();

                Session.SetString("Email", systemUser.Email);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfWork.SystemUserRepository.UserExists(systemUser.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
