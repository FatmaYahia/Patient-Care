using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace PatientCare.App.Controllers
{
    public class PatientController : Controller
    {

        private readonly DataContext DBContext;
        private readonly UnitOfWork UnitOfWork;
        private readonly IMapper _Mapper;
        public static List<string> documents = new List<string>();
        public static List<PatientDocument> Patientdocuments = new List<PatientDocument>();
        private readonly IHostingEnvironment HostingEnvironment;
        public static int PID;
        public static string incorrectPass;


        public PatientController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper, IHostingEnvironment hostingEnvironment)


        {
            this.UnitOfWork = UnitOfWork;
            this.DBContext = DBContext;
            _Mapper = Mapper;
            HostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            Patient p = new Patient();
            ViewBag.gender = new SelectList(UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name");
            ViewBag.BT = new SelectList(UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name");
            return View(p);
        }
        [HttpPost]
        public IActionResult Register(int id, Patient patient)
        {
            PatientDocument PD;
            if (ModelState.IsValid)
            {
                UnitOfWork.PatientRepository.CreateEntity(patient);
                UnitOfWork.PatientRepository.Save();
                if (documents.Count > 0)
                {
                    foreach (string item in documents)
                    {
                        PD = new PatientDocument() { Fk_Patient = patient.Id, ImgUrl = item };
                        UnitOfWork.PatientDocumentRepository.CreateEntity(PD);
                        UnitOfWork.PatientDocumentRepository.Save();
                    }
                }
                return Redirect($"/Home/Index");

            }
            ViewBag.gender = new SelectList(UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name");
            ViewBag.BT = new SelectList(UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name");

            return View(patient);

        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(Patient model)
        {

            List<Patient> patients = UnitOfWork.PatientRepository.GetAll();


            foreach (Patient item in patients)
            {

                if (model.Email == item.Email && model.Password == item.Password)
                {
                    //return Redirect($"/Home/Index");
                    return Redirect($"profile/{item.Id}");



                }
            }


            return View();
        }
        public IActionResult profile(int id)
        {
            PID = id;
            Patient patient = UnitOfWork.PatientRepository.GetByID(id);
            ViewBag.PID = id;
            return View(patient);
        }
        //Show Patient Health Information
        public IActionResult healthInfo(int id)
        {
            Patient patient = UnitOfWork.PatientRepository.GetByID(id);
            ViewBag.PID = id;
            return PartialView(patient);

        }
        //Back To Profile
        public IActionResult back(int id)
        {
            Patient patient = UnitOfWork.PatientRepository.GetByID(id);
            ViewBag.PID = id;
            return PartialView(patient);
        }
        public IActionResult editProfile(int id)
        {
            Patient patient = UnitOfWork.PatientRepository.GetByID(id);
            patient.ConfirmPassword = patient.Password;
            ViewBag.gender = new SelectList(UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name", patient.Fk_Gender);
            ViewBag.BT = new SelectList(UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name", patient.Fk_BloodType);

            return PartialView(patient);
        }
        [HttpPost]
        public IActionResult editProfile(int id, Patient patient)
        {
            Patient Data = UnitOfWork.PatientRepository.GetByID(id);
            _Mapper.Map(patient, Data);
            UnitOfWork.PatientRepository.UpdateEntity(Data);
            UnitOfWork.PatientRepository.Save();
            return Redirect($"/Patient/profile/{PID}");
        }
        //Change Password
        [HttpGet]
        public IActionResult checkPassword(int id)
        {
            ViewBag.ID = id;
            incorrectPass = "";
            return View();
        }

        //Change Password
        [HttpPost]
        public IActionResult checkPassword(int id, string oldPass)
        {
            //If Session[PatientID]!=null
            if (oldPass != UnitOfWork.PatientRepository.GetByID(id).Password)
            {
                incorrectPass = "You Entered Incorrect Password";
                ViewBag.Error = incorrectPass;
                return View();
            }
            else
            {
                incorrectPass = "";
                return RedirectToAction("ChangePass");
            }
        }
        [HttpGet]
        public IActionResult ChangePass()
        {
            //Session
            ViewBag.PID = PID;
            return View();
        }
        [HttpPost]
        public IActionResult ChangePass(string newPass)
        {
            //PID Here Is A Session
            Patient patient = UnitOfWork.PatientRepository.GetByID(PID);
            patient.Password = newPass;
            patient.ConfirmPassword = newPass;
            DBContext.SaveChanges();
            return RedirectToAction("profile", new { patient.Id });
        }
        //Documents
        [HttpPost]
        public IActionResult AddDocuments(IFormFile document)
        {
            string fileName = null;
            if (document != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments");
                fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                document.CopyTo(new FileStream(filePath, FileMode.Create));
                documents.Add(fileName);
            }
            ViewBag.documents = documents;
            return PartialView();
        }
        public IActionResult DeleteDocument(string file)
        {

            documents.Remove(file);
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments"), file)}");
            ViewBag.documents = documents;
            return PartialView();
        }
        public IActionResult PatientDocuments(int id)
        {
            if (Patientdocuments.Count > 0)
            {
                Patientdocuments = new List<PatientDocument>();
            }
            Patientdocuments = UnitOfWork.PatientDocumentRepository.GetAll().Where(n => n.Fk_Patient == id).ToList();
            ViewBag.PDs = Patientdocuments;
            ViewBag.PID = id;
            return PartialView();
        }
        public IActionResult AddPatientDocument(IFormFile document, int id)
        {
            string fileName = null;
            if (document != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments");
                fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                document.CopyTo(new FileStream(filePath, FileMode.Create));
                Patientdocuments.Add(new PatientDocument() { Fk_Patient = id, ImgUrl = fileName }); ;
            }
            ViewBag.PDs = Patientdocuments;
            ViewBag.PID = id;
            return PartialView();
        }
        public IActionResult DeletePatientDocument(int id, string ImgUrl)
        {

            Patientdocuments.Remove(Patientdocuments.Where(n => n.ImgUrl == ImgUrl).SingleOrDefault());
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments"), ImgUrl)}");
            ViewBag.PDs = Patientdocuments;
            ViewBag.PID = id;
            return PartialView();
        }
        public IActionResult SaveDocuments()
        {
            UnitOfWork.PatientDocumentRepository.upateTable(Patientdocuments);
            //Here will Be Session...
            return RedirectToAction(nameof(profile),new { id=PID});
        }

    }
}
