using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class ChatRepository : BaseRepository<Chat>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public ChatRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Chat> GetAll()
        {
            return DataBase.Chats.Include(n => n.Patient).Include(n => n.Doctor).ToList();
        }
    }
}
