using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AuthModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AuthRepository
{
    public class SystemUserRepository : BaseRepository<SystemUser>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public SystemUserRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public bool UserExists(string Email, string Password = null)
        {
            return DataBase.SystemUser
                   .Where(a => a.Email == Email)
                   .Where(a => Password == null ? true : a.Password == Password)
                   .Where(a => a.IsActive == true)
                   .Any();
        }

        public SystemUser GetByEmail(string Email)
        {
            return DataBase.SystemUser.FirstOrDefault(a => a.Email == Email);
        }

        public List<SystemUser> GetAllInclude()
        {
            return DataBase.SystemUser
                  .Include(a => a.SystemUserPermission)
                  .ToList();
        }
        public SystemUser GetByIDInclude(int id)
        {
            return DataBase.SystemUser
                  .Include(a => a.SystemUserPermission)
                  .Where(a => a.Id == id)
                  .FirstOrDefault();

        }


    }
}
