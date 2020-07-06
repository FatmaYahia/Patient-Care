using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class AgendaRepository : BaseRepository<Agenda>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public AgendaRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Agenda> GetAll()
        {
            return DataBase.Agendas.Include(n => n.Doctor).ToList();
        }
        public new Agenda GetByID(int id)
        {
            return DataBase.Agendas.Include(n => n.Doctor).Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
