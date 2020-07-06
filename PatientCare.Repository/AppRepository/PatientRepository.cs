using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class PatientRepository : BaseRepository<Patient>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public PatientRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Patient> GetAll()
        {
            return DataBase.Patients.Include(n => n.Gender).Include(n => n.BloodType).Include(n => n.PatientDocuments).ToList();
        }
        public new Patient GetByID(int id)
        {
            return DataBase.Patients.Include(n => n.Gender).Include(n => n.BloodType).Include(n => n.PatientDocuments).Where(n => n.Id == id).SingleOrDefault();
        }
        public Patient GetByPhoneOrEmail(string text)
        {
            return DataBase.Patients.Include(n => n.Gender).Include(n => n.BloodType).Include(n => n.PatientDocuments).Where(n => n.Phone == text || n.Email == text).SingleOrDefault();
        }

    }
}
