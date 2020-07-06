using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;

namespace PatientCare.Repository.AppRepository
{
    public class DonateTypeRepository : BaseRepository<DonateType>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public DonateTypeRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
    }
}
