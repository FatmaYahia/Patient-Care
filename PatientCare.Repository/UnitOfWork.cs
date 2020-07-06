using AutoMapper;
using PatientCare.DAL;
using PatientCare.Repository.AppRepository;
using PatientCare.Repository.AuthRepository;

namespace PatientCare.Repository
{
    public class UnitOfWork
    {
        private readonly DataContext DataBase;
        private readonly IMapper Mapper;
        public UnitOfWork(DataContext DataBase, IMapper Mapper)
        {
            this.DataBase = DataBase;
            this.Mapper = Mapper;
        }

        public AgendaRepository AgendaRepository => new AgendaRepository(DataBase, Mapper);
        public CityRepository CityRepository => new CityRepository(DataBase, Mapper);
        public BloodTypeRepository BloodTypeRepository => new BloodTypeRepository(DataBase, Mapper);
        public ChatRepository ChatRepository => new ChatRepository(DataBase, Mapper);
        public CoronaStatusRepository CoronaStatusRepository => new CoronaStatusRepository(DataBase, Mapper);
        public DoctorDocumentRepository DoctorDocumentRepository => new DoctorDocumentRepository(DataBase, Mapper);
        public DoctorRepository DoctorRepository => new DoctorRepository(DataBase, Mapper);
        public DonateTypeRepository DonateTypeRepository => new DonateTypeRepository(DataBase, Mapper);
        public DonationRepository DonationRepository => new DonationRepository(DataBase, Mapper);
        public GenderRepository GenderRepository => new GenderRepository(DataBase, Mapper);
        public HospitalRepository HospitalRepository => new HospitalRepository(DataBase, Mapper);
        public MessageRepository MessageRepository => new MessageRepository(DataBase, Mapper);
        public OfflineCoronaTestRepository OfflineCoronaTestRepository => new OfflineCoronaTestRepository(DataBase, Mapper);
        public OnlineCoronaTestRepository OnlineCoronaTestRepository => new OnlineCoronaTestRepository(DataBase, Mapper);
        public PatientDocumentRepository PatientDocumentRepository => new PatientDocumentRepository(DataBase, Mapper);
        public PatientRepository PatientRepository => new PatientRepository(DataBase, Mapper);
        public PharmacyRepository PharmacyRepository => new PharmacyRepository(DataBase, Mapper);
        public SpecializationRepository SpecializationRepository => new SpecializationRepository(DataBase, Mapper);

        //Auth (Custom Identity)
        public AccessLevelRepository AccessLevelRepository => new AccessLevelRepository(DataBase, Mapper);
        public SystemUserPermissionRepository SystemUserPermissionRepository => new SystemUserPermissionRepository(DataBase, Mapper);
        public SystemUserRepository SystemUserRepository => new SystemUserRepository(DataBase, Mapper);
        public SystemViewRepository SystemViewRepository => new SystemViewRepository(DataBase, Mapper);


    }
}
