using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class OfflineCoronaTestRepository : BaseRepository<OfflineCoronaTest>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public OfflineCoronaTestRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<OfflineCoronaTest> GetAll()
        {
            return DataBase.OfflineCoronaTests.Include(n => n.Patient.BloodType).Include(n => n.CoronaStatus).ToList();
        }

        public new OfflineCoronaTest GetByID(int id)
        {
            return DataBase.OfflineCoronaTests.Include(n => n.Patient.BloodType).Include(n => n.CoronaStatus).Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
