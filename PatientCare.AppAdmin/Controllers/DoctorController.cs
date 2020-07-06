using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCare.AppAdmin.Filters;
using PatientCare.Common;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static PatientCare.Common.DataEnum;

namespace PatientCare.AppAdmin.Controllers
{
    [Authorize((int)AccessLevelEnum.ViewAccess)]
    public class DoctorController : Controller
    {
        private readonly DataContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public static List<string> documents = new List<string>();
        public static List<DoctorDocument> doctorDocuments = new List<DoctorDocument>();
        private readonly IHostingEnvironment HostingEnvironment;
        public DoctorController(DataContext DBContext, UnitOfWork UnitOfWork, IMapper Mapper, IHostingEnvironment hostingEnvironment)
        {
            _DBContext = DBContext;
            _UnitOfWork = UnitOfWork;
            _Mapper = Mapper;
            HostingEnvironment = hostingEnvironment;
        }
        //Getall
        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            return View(_UnitOfWork.DoctorRepository.GetAll());
        }
        [Authorize((int)AccessLevelEnum.ViewAccess)]


        public IActionResult Details(int id)
        {
            Doctor Doctor = _UnitOfWork.DoctorRepository.GetByID(id);
            string g = Doctor.Gender.Name;
            if (Doctor == null)
            {
                return NotFound();
            }
            return View(Doctor);
        }

        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (documents.Count > 0)
            {
                documents = new List<string>();
            }
            Doctor Doctor = new Doctor();
            List<Gender> Genders = _UnitOfWork.GenderRepository.GetAll();
            SelectList GenderLists = new SelectList(Genders, "Id", "Name");
            ViewBag.Genders = GenderLists;

            List<Specialization> Specializations = _UnitOfWork.SpecializationRepository.GetAll();
            SelectList SpecializationList = new SelectList(Specializations, "Id", "Name");
            ViewBag.Specialization = SpecializationList;


            if (id > 0)
            {
                Doctor = _UnitOfWork.DoctorRepository.GetByID(id);
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
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.ControlAccess)]
        public async Task<IActionResult> CreateOrEdit(int id, Doctor Doctor)
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
                        _UnitOfWork.DoctorRepository.CreateEntity(Doctor);
                        _UnitOfWork.DoctorRepository.Save();
                        if (documents.Count > 0)
                        {
                            foreach (string item in documents)
                            {
                                DD = new DoctorDocument() { Fk_Doctor = Doctor.Id, ImgUrl = item };
                                _UnitOfWork.DoctorDocumentRepository.CreateEntity(DD);
                                _UnitOfWork.DoctorDocumentRepository.Save();
                            }
                        }

                    }
                    else
                    {
                        Doctor Data = _UnitOfWork.DoctorRepository.GetByID(id);
                        _Mapper.Map(Doctor, Data);
                        _UnitOfWork.DoctorRepository.UpdateEntity(Data);
                        _UnitOfWork.DoctorRepository.Save();

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
                            _UnitOfWork.DoctorRepository.UpdateEntity(Doctor);
                            _UnitOfWork.DoctorRepository.Save();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UnitOfWork.DoctorRepository.Any(a => a.Id == id))
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

            return View(Doctor);
        }
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult Delete(int id)
        {
            Doctor Doctor = _UnitOfWork.DoctorRepository.GetByID(id);
            if (Doctor == null)
            {
                return NotFound();
            }

            return View(Doctor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize((int)AccessLevelEnum.FullAccess)]
        public IActionResult DeleteConfirmed(int id)
        {
            Doctor Doctor = _UnitOfWork.DoctorRepository.GetByID(id);
            _UnitOfWork.DoctorRepository.DeleteEntity(Doctor);

            _UnitOfWork.GenderRepository.Save();
            return RedirectToAction(nameof(Index));
        }
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
            doctorDocuments = _UnitOfWork.DoctorDocumentRepository.GetAll().Where(n => n.Fk_Doctor == id).ToList();
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
            _UnitOfWork.DoctorDocumentRepository.upateTable(doctorDocuments);
            return RedirectToAction(nameof(Index));
        }



    }
}

