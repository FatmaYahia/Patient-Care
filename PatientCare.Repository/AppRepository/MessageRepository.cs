using AutoMapper;
using PatientCare.BaseRepository;
using PatientCare.DAL;
using PatientCare.Entity.AppModel;

namespace PatientCare.Repository.AppRepository
{
    public class MessageRepository : BaseRepository<Message>
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public MessageRepository(DataContext DataBase, IMapper Mapper) : base(DataBase)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }
    }
}
