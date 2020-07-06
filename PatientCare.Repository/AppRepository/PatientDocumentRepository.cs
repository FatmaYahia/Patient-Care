using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.Repository.AppRepository
{
    public class PatientDocumentRepository : BaseRepository<PatientDocument>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public PatientDocumentRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
        public new List<PatientDocument> GetAll()
        {
            return DataBase.PatientDocuments.Include(n => n.Patient).ToList();
        }
        public new PatientDocument GetByID(int id)
        {
            return DataBase.PatientDocuments.Include(n => n.Patient).Where(n => n.Id == id).SingleOrDefault();
        }
        public List<PatientDocument> GetPatientDocuments(int id)
        {
            return DataBase.PatientDocuments.Include(n => n.Patient).Where(n => n.Fk_Patient == id).ToList();
        }
        public void upateTable(List<PatientDocument> updatedData)
        {
            foreach (PatientDocument item in updatedData)
            {
                if (!DataBase.PatientDocuments.Any(n => n.ImgUrl == item.ImgUrl))
                {
                    DataBase.PatientDocuments.Add(item);
                }
            }

            foreach (PatientDocument item in DataBase.PatientDocuments)
            {
                if (!updatedData.Any(n => n.ImgUrl == item.ImgUrl))
                {
                    DataBase.PatientDocuments.Remove(item);

                }

            }
            DataBase.SaveChanges();
        }
    }
}
