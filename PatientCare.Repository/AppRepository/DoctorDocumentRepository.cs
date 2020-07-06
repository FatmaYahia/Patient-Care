using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class DoctorDocumentRepository : BaseRepository<DoctorDocument>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public DoctorDocumentRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public void upateTable(List<DoctorDocument> updatedData)
        {
            foreach (DoctorDocument item in updatedData)
            {
                if (!DataBase.DoctorDocuments.Any(n => n.ImgUrl == item.ImgUrl))
                {
                    DataBase.DoctorDocuments.Add(item);
                }
            }

            foreach (DoctorDocument item in DataBase.DoctorDocuments)
            {
                if (!updatedData.Any(n => n.ImgUrl == item.ImgUrl))
                {
                    DataBase.DoctorDocuments.Remove(item);

                }

            }
            DataBase.SaveChanges();
        }

    }
}
