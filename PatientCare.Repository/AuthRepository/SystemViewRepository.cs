using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AuthRepository
{
    public class SystemViewRepository : BaseRepository<SystemView>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public SystemViewRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }

        public List<SystemView> GetSystemViews(string Email, int Fk_AccessLevel = 0)
        {
            return DataBase.SystemUserPermission
                .Where(a => a.SystemUser.Email == Email)
                .Where(a => (Fk_AccessLevel == 0) ? true : a.Fk_AccessLevel == Fk_AccessLevel)
                .Select(a => a.SystemView)
                .ToList();
        }
    }
}
