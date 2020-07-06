using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class HospitalRepository : BaseRepository<Hospital>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public HospitalRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Hospital> GetAll()
        {
            return DataBase.Hospitals.Include(n => n.City).ToList();
        }
        public List<Hospital> GetByCity(int id)
        {
            return DataBase.Hospitals.Include(n => n.City).Where(n => n.Fk_City == id).ToList();
        }
        public new Hospital GetByID(int id)
        {
            return DataBase.Hospitals.Include(n => n.City).Where(n => n.Id == id).SingleOrDefault();
        }

    }
}
