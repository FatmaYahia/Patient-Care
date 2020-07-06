using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class DoctorRepository : BaseRepository<Doctor>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public DoctorRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Doctor> GetAll()
        {
            return DataBase.Doctors.Include(n => n.Gender).Include(n => n.Specialization).ToList();
        }
        public new Doctor GetByID(int id)
        {
            return DataBase.Doctors.Include(n => n.Gender).Include(n => n.Specialization).Where(n => n.Id == id).SingleOrDefault();
        }
        public Doctor GetByPhoneOrEmail(string text)
        {
            return DataBase.Doctors.Include(n => n.Gender).Include(n => n.DoctorDocuments).Where(n => n.Phone == text || n.Email == text).SingleOrDefault();
        }
    }
}
