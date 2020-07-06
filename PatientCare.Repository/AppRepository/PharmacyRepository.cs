using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class PharmacyRepository : BaseRepository<Pharmacy>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public PharmacyRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }

        public new List<Pharmacy> GetAll()
        {
            return DataBase.Pharmacies.Include(n => n.City).ToList();
        }
        public new Pharmacy GetByID(int id)
        {
            return DataBase.Pharmacies.Include(n => n.City).Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
