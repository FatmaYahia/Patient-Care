using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCare.Common;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PatientCare.App.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;
        private readonly UnitOfWork UnitOfWork;
        public static List<string> documents = new List<string>();
        public static List<DoctorDocument> doctorDocuments = new List<DoctorDocument>();
        private readonly IHostingEnvironment HostingEnvironment;
        public static int PID;
        public static string incorrectPass;


        public DoctorController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper _Mapper, IHostingEnvironment hostingEnvironment)
        {
            this.UnitOfWork = UnitOfWork;
            this.DBContext = DBContext;
            this._Mapper = _Mapper;
            HostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string Name, int Fk_Specialization = 0, int Fk_Gender = 0)
        {
            return View(DBContext.Doctors.Where(a => a.IsVerified == true)
                                        .Where(a => string.IsNullOrEmpty(Name) || a.FullName.Contains(Name))
                                        .Where(a => Fk_Specialization == 0 || a.Fk_Specialization == Fk_Specialization)
                                        .Where(a => Fk_Gender == 0 || a.Fk_Gender == Fk_Gender)
                                        .Include(a => a.Specialization)
                                        .ToList());
        }
        public IActionResult register(int id = 0)
        {
            if (documents.Count > 0)
            {
                documents = new List<string>();
            }
            Doctor Doctor = new Doctor();
            List<Gender> Genders = UnitOfWork.GenderRepository.GetAll();
            SelectList GenderLists = new SelectList(Genders, "Id", "Name");
            ViewBag.Genders = GenderLists;

            List<Specialization> Specializations = UnitOfWork.SpecializationRepository.GetAll();
            SelectList SpecializationList = new SelectList(Specializations, "Id", "Name");
            ViewBag.Specialization = SpecializationList;
            if (id > 0)
            {
                Doctor = UnitOfWork.DoctorRepository.GetByID(id);
                if (Doctor == null)
                {
                    return NotFound();
                }
                Doctor.ConfirmPassword = Doctor.Password;
                ViewBag.Genders = GenderLists;
                ViewBag.Specialization = SpecializationList;
            }
            return View(Doctor);
        }
        [HttpPost]
        public async Task<IActionResult> register(int id, Doctor Doctor)
        {
            DoctorDocument DD;
            if (id != Doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        UnitOfWork.DoctorRepository.CreateEntity(Doctor);
                        UnitOfWork.DoctorRepository.Save();
                        if (documents.Count > 0)
                        {
                            foreach (string item in documents)
                            {
                                DD = new DoctorDocument() { Fk_Doctor = Doctor.Id, ImgUrl = item };
                                UnitOfWork.DoctorDocumentRepository.CreateEntity(DD);
                                UnitOfWork.DoctorDocumentRepository.Save();
                            }
                        }

                    }
                    else
                    {
                        Doctor Data = UnitOfWork.DoctorRepository.GetByID(id);
                        _Mapper.Map(Doctor, Data);
                        UnitOfWork.DoctorRepository.UpdateEntity(Data);
                        UnitOfWork.DoctorRepository.Save();

                        Doctor = Data;
                    }

                    IFormFile files = HttpContext.Request.Form.Files["ImageFile"];
                    if (files != null)
                    {
                        ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                        string ImgURl = await ImgManager.UploudImageAsync(AppMainData.DomainName, Doctor.Id.ToString(), files, "Uploud/Doctor");

                        if (!string.IsNullOrEmpty(ImgURl))
                        {
                            if (!string.IsNullOrEmpty(Doctor.ImgUrl))
                            {
                                ImgManager.DeleteImage(Doctor.ImgUrl, AppMainData.DomainName);
                            }
                            Doctor.ImgUrl = ImgURl;
                            UnitOfWork.DoctorRepository.UpdateEntity(Doctor);
                            UnitOfWork.DoctorRepository.Save();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitOfWork.DoctorRepository.Any(a => a.Id == id))
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

            List<Gender> Genders = UnitOfWork.GenderRepository.GetAll();
            SelectList GenderLists = new SelectList(Genders, "Id", "Name");
            ViewBag.Genders = GenderLists;

            List<Specialization> Specializations = UnitOfWork.SpecializationRepository.GetAll();
            SelectList SpecializationList = new SelectList(Specializations, "Id", "Name");
            ViewBag.Specialization = SpecializationList;
            return View(Doctor);
        }
        public IActionResult profile(int id = 0)
        {
            PID = id;
            Doctor Doctor = UnitOfWork.DoctorRepository.GetByID(id);
            //  string g = Doctor.Gender.Name;
            if (Doctor == null)
            {
                return NotFound();
            }
            return View(Doctor);
        }
        //Back To Profile
        public IActionResult back(int id)
        {
            Doctor doctor = UnitOfWork.DoctorRepository.GetByID(id);
            ViewBag.PID = id;
            return PartialView(doctor);
        }
        public IActionResult edit(int id = 0)
        {
            if (documents.Count > 0)
            {
                documents = new List<string>();
            }
            Doctor Doctor = new Doctor();
            List<Gender> Genders = UnitOfWork.GenderRepository.GetAll();
            SelectList GenderLists = new SelectList(Genders, "Id", "Name");
            ViewBag.Genders = GenderLists;

            List<Specialization> Specializations = UnitOfWork.SpecializationRepository.GetAll();
            SelectList SpecializationList = new SelectList(Specializations, "Id", "Name");
            ViewBag.Specialization = SpecializationList;


            if (id > 0)
            {
                Doctor = UnitOfWork.DoctorRepository.GetByID(id);
                if (Doctor == null)
                {
                    return NotFound();
                }
                Doctor.ConfirmPassword = Doctor.Password;
                ViewBag.Genders = GenderLists;
                ViewBag.Specialization = SpecializationList;
            }
            return PartialView(Doctor);
        }
        [HttpPost]
        public IActionResult edit(int id, Doctor Doctor)
        {
            DoctorDocument DD;
            if (id != Doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        UnitOfWork.DoctorRepository.CreateEntity(Doctor);
                        UnitOfWork.DoctorRepository.Save();
                        if (documents.Count > 0)
                        {
                            foreach (string item in documents)
                            {
                                DD = new DoctorDocument() { Fk_Doctor = Doctor.Id, ImgUrl = item };
                                UnitOfWork.DoctorDocumentRepository.CreateEntity(DD);
                                UnitOfWork.DoctorDocumentRepository.Save();
                            }
                        }

                    }
                    else
                    {
                        Doctor Data = UnitOfWork.DoctorRepository.GetByID(id);
                        _Mapper.Map(Doctor, Data);
                        UnitOfWork.DoctorRepository.UpdateEntity(Data);
                        UnitOfWork.DoctorRepository.Save();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitOfWork.DoctorRepository.Any(a => a.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/Doctor/profile/{PID}");
            }

            return Redirect($"/Doctor/profile/{PID}");
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
            if (oldPass != UnitOfWork.DoctorRepository.GetByID(id).Password)
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
            Doctor doctor = UnitOfWork.DoctorRepository.GetByID(PID);
            doctor.Password = newPass;
            doctor.ConfirmPassword = newPass;
            DBContext.SaveChanges();
            return RedirectToAction("profile", new { doctor.Id });
        }

        //Documents
        [HttpPost]
        public IActionResult AddDocuments(IFormFile document)
        {
            string fileName = null;
            if (document != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "DoctorDocuments");
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
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "DoctorDocuments"), file)}");
            ViewBag.documents = documents;
            return PartialView();
        }

        public IActionResult DoctorDocuments(int id)
        {
            if (doctorDocuments.Count > 0)
            {
                doctorDocuments = new List<DoctorDocument>();
            }
            doctorDocuments = UnitOfWork.DoctorDocumentRepository.GetAll().Where(n => n.Fk_Doctor == id).ToList();
            ViewBag.DDs = doctorDocuments;
            ViewBag.DID = id;
            return PartialView();
        }
        public IActionResult AddDoctorDocument(IFormFile document, int id)
        {
            string fileName = null;
            if (document != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "DoctorDocuments");
                fileName = Guid.NewGuid().ToString() + "_" + document.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                document.CopyTo(new FileStream(filePath, FileMode.Create));
                doctorDocuments.Add(new DoctorDocument() { Fk_Doctor = id, ImgUrl = fileName }); ;
            }
            ViewBag.DDs = doctorDocuments;
            ViewBag.DID = id;
            return PartialView();
        }
        public IActionResult DeleteDoctorDocument(int id, string ImgUrl)
        {

            doctorDocuments.Remove(doctorDocuments.Where(n => n.ImgUrl == ImgUrl).SingleOrDefault());
            //System.IO.File.Delete($"{Path.Combine(Path.Combine(HostingEnvironment.WebRootPath, "DoctorDocuments"), ImgUrl)}");
            ViewBag.DDs = doctorDocuments;
            ViewBag.DID = id;
            return PartialView();
        }
        public IActionResult SaveDocuments()
        {
            UnitOfWork.DoctorDocumentRepository.upateTable(doctorDocuments);
            return RedirectToAction(nameof(profile), new { id = PID });
        }



    }
}

