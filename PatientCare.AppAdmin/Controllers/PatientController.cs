using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientCare.AppAdmin.Filters;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers

{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class PatientController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public static List<string> documents = new List<string>();
        public static List<PatientDocument> Patientdocuments = new List<PatientDocument>();
        private readonly IHostingEnvironment HostingEnvironment;

        public PatientController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper, IHostingEnvironment hostingEnvironment)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            HostingEnvironment = hostingEnvironment;
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.PatientRepository.GetAll());
        }

        [HttpGet]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (documents.Count > 0)
            {
                documents = new List<string>();
            }
            Patient patient = new Patient();
            if (id > 0)
            {
                patient = _UnitOfWork.PatientRepository.GetByID(id);

                if (patient == null)
                {
                    return NotFound();
                }
                patient.ConfirmPassword = patient.Password;
                ViewBag.gender = new SelectList(_UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name", patient.Fk_Gender);
                ViewBag.BT = new SelectList(_UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name", patient.Fk_BloodType);
            }
            else
            {
                ViewBag.gender = new SelectList(_UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name");
                ViewBag.BT = new SelectList(_UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name");
            }

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id, Patient patient)
        {
            PatientDocument PD;
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _UnitOfWork.PatientRepository.CreateEntity(patient);
                    _UnitOfWork.PatientRepository.Save();
                    if (documents.Count > 0)
                    {
                        foreach (string item in documents)
                        {
                            PD = new PatientDocument() { Fk_Patient = patient.Id, ImgUrl = item };
                            _UnitOfWork.PatientDocumentRepository.CreateEntity(PD);
                            _UnitOfWork.PatientDocumentRepository.Save();
                        }
                    }

                }
                else
                {
                    Patient Data = _UnitOfWork.PatientRepository.GetByID(id);

                    _Mapper.Map(patient, Data);

                    _UnitOfWork.PatientRepository.UpdateEntity(Data);
                    _UnitOfWork.PatientRepository.Save();

                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.gender = new SelectList(_UnitOfWork.GenderRepository.GetAll().ToList(), "Id", "Name");
            ViewBag.BT = new SelectList(_UnitOfWork.BloodTypeRepository.GetAll().ToList(), "Id", "Name");
            return View(patient);
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Details(int id)
        {
            Patient patient = _UnitOfWork.PatientRepository.GetByID(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Patient patient = _UnitOfWork.PatientRepository.GetByID(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Patient patient = _UnitOfWork.PatientRepository.GetByID(id);
            _UnitOfWork.PatientRepository.DeleteEntity(patient);
            _UnitOfWork.PatientRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        //Add Documents
        [HttpPost]
        [Authorize((int)AccessLevelEnum.FullAccess)]
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
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteDocument(string file)
        {

            documents.Remove(file);
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments"), file)}");
            ViewBag.documents = documents;
            return PartialView();
        }
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult PatientDocuments(int id)
        {
            if (Patientdocuments.Count > 0)
            {
                Patientdocuments = new List<PatientDocument>();
            }
            Patientdocuments = _UnitOfWork.PatientDocumentRepository.GetAll().Where(n => n.Fk_Patient == id).ToList();
            ViewBag.PDs = Patientdocuments;
            ViewBag.PID = id;
            return PartialView();
        }

        [Authorize((int)AccessLevelEnum.FullAccess)]
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
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeletePatientDocument(int id, string ImgUrl)
        {

            Patientdocuments.Remove(Patientdocuments.Where(n => n.ImgUrl == ImgUrl).SingleOrDefault());
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "patientDocuments"), ImgUrl)}");
            ViewBag.PDs = Patientdocuments;
            ViewBag.PID = id;
            return PartialView();
        }
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult SaveDocuments()
        {
            _UnitOfWork.PatientDocumentRepository.upateTable(Patientdocuments);
            return RedirectToAction(nameof(Index));
        }

    }
}