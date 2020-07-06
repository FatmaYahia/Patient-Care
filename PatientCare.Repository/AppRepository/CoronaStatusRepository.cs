using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class CoronaStatusRepository : BaseRepository<CoronaStatus>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public CoronaStatusRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public List<CoronaStatus> getOfflineStatus()
        {
            return DataBase.CoronaStatuses.Where(n => n.Name.Contains("Positive") || n.Name.Contains("Negative")).ToList();
        }
    }
}
