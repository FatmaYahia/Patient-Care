using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class OnlineCoronaTestRepository : BaseRepository<OnlineCoronaTest>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public OnlineCoronaTestRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<OnlineCoronaTest> GetAll()
        {
            return DataBase.OnlineCoronaTests.Include(n => n.Patient).ToList();
        }
        public new OnlineCoronaTest GetById(int id)
        {
            return DataBase.OnlineCoronaTests.Include(n => n.Patient).Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
