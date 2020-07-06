using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class SpecializationRepository : BaseRepository<Specialization>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public SpecializationRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }

        public List<Specialization> GetAllInclude()
        {
            return DataBase.Specializations
                .Include(a => a.Doctors).ToList();
        }
    }
}
