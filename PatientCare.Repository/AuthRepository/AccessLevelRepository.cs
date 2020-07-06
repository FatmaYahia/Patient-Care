using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;

namespace PatientCare.Repository.AuthRepository
{
    public class AccessLevelRepository : BaseRepository<AccessLevel>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public AccessLevelRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }

    }
}
