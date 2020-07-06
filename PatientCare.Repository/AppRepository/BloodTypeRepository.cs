using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;

namespace PatientCare.Repository.AppRepository
{
    public class BloodTypeRepository : BaseRepository<BloodType>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public BloodTypeRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
    }
}
