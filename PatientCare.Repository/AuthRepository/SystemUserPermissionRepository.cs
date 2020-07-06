using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using System.Linq;
using static PatientCare.Common.DataEnum;

namespace PatientCare.Repository.AuthRepository
{
    public class SystemUserPermissionRepository : BaseRepository<SystemUserPermission>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public SystemUserPermissionRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public bool CheckAuthorization(string ViewName, int Fk_AccessLevel, string Email)
        {
            if (Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
            {
                return IsFullAccess(ViewName, Email);
            }
            else if (Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
            {
                return IsControlAccess(ViewName, Email);
            }
            else if (Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
            {
                return IsViewAccess(ViewName, Email);
            }
            return false;
        }
        public bool IsFullAccess(string ViewName, string Email)
        {
            return DataBase.SystemUserPermission.Where(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName &&
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
                                                 .Any();
        }
        public bool IsControlAccess(string ViewName, string Email)
        {
            return DataBase.SystemUserPermission.Where(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName)
                                                 .Where(a => a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess ||
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
                                                 .Any();
        }
        public bool IsViewAccess(string ViewName, string Email)
        {
            return DataBase.SystemUserPermission.Where(a => a.SystemUser.Email == Email && a.SystemView.Name == ViewName &&
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess ||
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess ||
                                                             a.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                                                 .Any();
        }
    }
}
