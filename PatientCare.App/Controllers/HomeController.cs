using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientCare.App.Models;
using PatientCare.AppAdmin.Models;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;

using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PatientCare.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext DBContext;
        private readonly UnitOfWork UnitOfWork;
        private readonly ISession Session;


        public HomeController(ILogger<HomeController> logger, DataContext DBContext, UnitOfWork UnitOfWork, IHttpContextAccessor HttpContextAccessor)
        {
            _logger = logger;
            this.DBContext = DBContext;
            this.UnitOfWork = UnitOfWork;
            Session = HttpContextAccessor.HttpContext.Session;

        }

        public IActionResult Index()
        {
            var Data = UnitOfWork.SpecializationRepository.GetAllInclude();
            Data.ForEach(a => a.Doctors = a.Doctors.Where(a => a.IsVerified == true).ToList());
            return View(Data);

        }
        public IActionResult Hospitals()
        {

            return View();
        }
        public IActionResult hospitalsByCity(int id)
        {

            List<Hospital> hospitals = UnitOfWork.HospitalRepository.GetByCity(id).OrderByDescending(n => n.AvailableBeds).ThenByDescending(n => n.LastModifiedAt).ToList();
            return PartialView(hospitals);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult getLocation(int id)
        //{
        //    var data = UnitOfWork.HospitalRepository.GetByID(id);

        //    return View(data);
        //    //return Json(data, new Newtonsoft.Json.JsonSerializerSettings());
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult login(LoginViewModel loginViewModel)
        {

            List<Doctor> Doctors = UnitOfWork.DoctorRepository.GetAll();
            foreach (Doctor item in Doctors)
            {

                if (loginViewModel.Email == item.Email && loginViewModel.Password == item.Password)
                {
                    Session.SetString("Id", item.Id.ToString());
                    Session.SetString("Email", item.Email);
                    Session.SetString("IsDoctor", "True");
                    if (loginViewModel.RememberMe == true)
                    {
                        CookieOptions cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(7)
                        };
                        Response.Cookies.Append("Id", item.Id.ToString(), cookieOptions);
                    }
                    return Redirect($"/Doctor/Profile/{item.Id}");

                }
            }
            List<Patient> Patients = UnitOfWork.PatientRepository.GetAll();
            foreach (Patient item in Patients)
            {
                if (loginViewModel.Email == item.Email && loginViewModel.Password == item.Password)
                {
                    Session.SetString("Id", item.Id.ToString());
                    Session.SetString("Email", item.Email);
                    Session.SetString("IsPatient", "True");
                    if (loginViewModel.RememberMe == true)
                    {
                        CookieOptions cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(7)
                        };
                        Response.Cookies.Append("Id", item.Id.ToString(), cookieOptions);
                    }
                    return Redirect($"/Patient/Profile/{item.Id}");
                }

            }
            ViewData["Error"] = "Email or Password Are Wrong, Or Acount Is Deactive!";
            return View();
        }

        public IActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
