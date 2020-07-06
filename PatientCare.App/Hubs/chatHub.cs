using Microsoft.AspNetCore.SignalR;
using PatientCare.Entity.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PatientCare.DAL;
using PatientCare.Repository;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PatientCare.App.Hubs
{
    public class chatHub :Hub
    {
        private readonly DataContext DBContext;
        private readonly UnitOfWork UnitOfWork;
        public chatHub(DataContext DBContext, UnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
            this.DBContext = DBContext;
        }
        public string getConnectionId() => Context.ConnectionId;
    }
}
