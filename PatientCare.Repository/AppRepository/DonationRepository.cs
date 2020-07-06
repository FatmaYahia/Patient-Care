using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class DonationRepository : BaseRepository<Donation>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public DonationRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<Donation> GetAll()
        {
            return DataBase.Donations.Include(n => n.Patient.BloodType).Include(n => n.DonateType).ToList();
        }

        public new Donation GetByID(int id)
        {
            return DataBase.Donations.Include(n => n.Patient.BloodType).Include(n => n.DonateType).Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
