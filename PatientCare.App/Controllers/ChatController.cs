using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PatientCare.App.Hubs;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using PatientCare.Repository;

namespace PatientCare.App.Controllers
{
   // [Authorize]
    public class ChatController : Controller
    {
        public static bool isdoct = false;
        public static bool isview = false;
        public static bool isViewed = false;
        private readonly DataContext DBContext;
        private readonly UnitOfWork UnitOfWork;
        public IHubContext<chatHub> _chat;
        private readonly ISession Session;
        public ChatController(DataContext DBContext, UnitOfWork UnitOfWork, IHubContext<chatHub> chat, IHttpContextAccessor HttpContextAccessor)
        {
            this.UnitOfWork = UnitOfWork;
            this.DBContext = DBContext;
            _chat = chat;
            Session = HttpContextAccessor.HttpContext.Session;
        }
        public IActionResult privateRooms ()
        {
           
            if (string.IsNullOrEmpty(Session.GetString("Email")) ||string.IsNullOrEmpty(Session.GetString("Id")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                int UserId = int.Parse(Session.GetString("Id"));
                string UserEmail = Session.GetString("Email");
                var user = DBContext.Patients.Where(a => a.Email == UserEmail).Include(a => a.Chats).FirstOrDefault();
                List<Chat> chats = new List<Chat>();
                if (user == null)
                {
                    isdoct = true;
                    chats = DBContext.Chats
                   .Include(x => x.Doctor)
                   .Include(x => x.Patient)
                   .Where(x => x.Fk_Doctor == UserId)
                   .ToList();
                }
                else
                {
                    isdoct = false;
                    chats = DBContext.Chats
                   .Include(x => x.Doctor)
                   .Include(x => x.Patient)
                   .Where(x => x.Fk_Patient == UserId)
                   .ToList();
                }

                ViewBag.isdoct = isdoct;
                return View(chats);
            }
        }
        public IActionResult CheckValidRoom (int id)
        {
            
            if (string.IsNullOrEmpty(Session.GetString("Email")) || string.IsNullOrEmpty(Session.GetString("Id")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                int UserId = int.Parse(Session.GetString("Id"));
                var chat = DBContext.Chats.Where(a => a.Fk_Doctor == id && a.Fk_Patient == UserId).FirstOrDefault();
                if (chat == null)
                {
                    return RedirectToAction("createPrivateRoom", new { id = id });
                }
                else
                {
                    return RedirectToAction("Chat", new { id = chat.Id });
                }
            }
           
        }
        public  IActionResult createPrivateRoom(int id)
        {
            
            if (string.IsNullOrEmpty(Session.GetString("Email")) || string.IsNullOrEmpty(Session.GetString("Id")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                int UserId = int.Parse(Session.GetString("Id"));
                string UserEmail = Session.GetString("Email");
                var user = DBContext.Patients.Where(a => a.Email == UserEmail).Include(a => a.Chats).FirstOrDefault();
                string UserName = user.FullName;
                var chat = new Chat();
                chat.Fk_Doctor = id;
                chat.Fk_Patient = UserId;
                UnitOfWork.ChatRepository.CreateEntity(chat);
                UnitOfWork.ChatRepository.Save();
                return RedirectToAction("Chat", new { id = chat.Id });
            }
        }
            [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Chat(int id)
        {
            
            if (string.IsNullOrEmpty(Session.GetString("Email")) || string.IsNullOrEmpty(Session.GetString("Id")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                string UserEmail = Session.GetString("Email");
                var user = DBContext.Patients.Where(a => a.Email == UserEmail).Include(a => a.Chats).FirstOrDefault();
                string UserName = user.FullName;
                var chat = DBContext.Chats
                    .Include(x => x.Messages)
                    .ThenInclude(y => y.Chat)
                    .ThenInclude(z => z.Patient)
                    .Include(a => a.Doctor)
                    .FirstOrDefault(x => x.Id == id);
                ViewBag.UserName = UserName;
                return View(chat);
            }
        }
        [HttpPost]
        public IActionResult CreateMessage(int chatId, string message)
        {
            
            if (string.IsNullOrEmpty(Session.GetString("Email")) || string.IsNullOrEmpty(Session.GetString("Id")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                string UserEmail = Session.GetString("Email");
                var doctors = DBContext.Doctors.ToList();
                foreach (var item in doctors)
                {
                    if (UserEmail == item.Email)
                    {
                        isdoct = true;
                        isview = item.IsOnline;
                    }
                }
                var Message = new Message
                {
                    Fk_Chat = chatId,
                    MessageContent = message,
                    IsViewd = isview,
                    IsDoctor = isdoct
                };
                UnitOfWork.MessageRepository.CreateEntity(Message);
                UnitOfWork.MessageRepository.Save();
                var chat = DBContext.Chats.Where(a => a.Id == chatId).FirstOrDefault();
                chat.Messages.Add(Message);
                UnitOfWork.ChatRepository.Save();
                return RedirectToAction("Chat", new { id = chatId });
            }
            
        }

        [HttpPost("[controller]/[action]/{connectionId}/{roomId}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomId)
        {

            await _chat.Groups.AddToGroupAsync(connectionId, roomId);

            return Ok();
        }
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> SendMessage(int chatId,string message)
        {
           
            if (string.IsNullOrEmpty(Session.GetString("Email")))
            {
                return Redirect($"/Home/login");
            }
            else
            {
                string UserEmail = Session.GetString("Email");
                var doctors = DBContext.Doctors.ToList();
                foreach (var item in doctors)
                {
                    if (item.Email == UserEmail)
                    {
                        isdoct = true;
                    }
                }
                var Message = new Message
                {
                    Fk_Chat = chatId,
                    MessageContent = message,
                    IsViewd = false,
                    IsDoctor = isdoct
                };
                UnitOfWork.MessageRepository.CreateEntity(Message);
                UnitOfWork.MessageRepository.Save();
                var chat = DBContext.Chats.Where(a => a.Id == chatId).FirstOrDefault();
                chat.Messages.Add(Message);
                UnitOfWork.ChatRepository.Save();
                await _chat.Clients.Group(chatId.ToString()).SendAsync("receiveMessage", Message);
                return Ok();
            }
        }
    }
}
