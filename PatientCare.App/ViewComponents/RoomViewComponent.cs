using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCare.DAL;
using PatientCare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientCare.App.ViewComponents
{
    public class RoomViewComponent:ViewComponent
    {
       
        private readonly DataContext DBContext;
        private readonly UnitOfWork UnitOfWork;
        private readonly ISession Session;
        public RoomViewComponent(DataContext DBContext, UnitOfWork UnitOfWork, IHttpContextAccessor HttpContextAccessor)
        {
            this.UnitOfWork = UnitOfWork;
            this.DBContext = DBContext;
            Session = HttpContextAccessor.HttpContext.Session;
        }
        public IViewComponentResult Invoke()
        {
                string UserEmail = Session.GetString("Email");
                var chats = DBContext.Chats.Where(a => a.Patient.Email == UserEmail || a.Doctor.Email == UserEmail)
                    .Include(x => x.Messages).ToList();
                return View(chats);
            
        }
    }
}
