using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.App.Controllers
{
    public class DonationController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly ISession Session;

        public DonationController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper, IHttpContextAccessor HttpContextAccessor)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            Session = HttpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
        public IActionResult donations()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Donate()
        {
            string Email = Session.GetString("Email");
            if (string.IsNullOrEmpty(Email))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Donate(Donation Donation)
        {
            string PatientID = Session.GetString("Id");
            Donation.Fk_Patient = int.Parse(PatientID);
            _UnitOfWork.DonationRepository.CreateEntity(Donation);
            _UnitOfWork.DonationRepository.Save();

            return Redirect($"/Donation/donations");
        }


        public IActionResult Donor()
        {
            List<Donation> donations = _UnitOfWork.DonationRepository.GetAll().ToList();
            return View(donations);
        }
    }

}

