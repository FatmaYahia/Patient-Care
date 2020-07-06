using AutoMapper;
using PatientCare.Entity.AppModel;
using PatientCare.Entity.AuthModel;

namespace PatientCare.Repository.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SystemView, SystemView>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
              .ForMember(dest => dest.SystemUserPermission, opt => opt.Ignore());

            CreateMap<SystemUser, SystemUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.SystemUserPermission, opt => opt.Ignore());

            CreateMap<Gender, Gender>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Patients, opt => opt.Ignore())
                .ForMember(dest => dest.Doctors, opt => opt.Ignore());

            CreateMap<City, City>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Hospitals, opt => opt.Ignore())
                .ForMember(dest => dest.Pharmacies, opt => opt.Ignore());

            CreateMap<Patient, Patient>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Gender, opt => opt.Ignore())
            .ForMember(dest => dest.BloodType, opt => opt.Ignore());

            CreateMap<Donation, Donation>()
          .ForMember(dest => dest.Id, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
          .ForMember(dest => dest.Patient, opt => opt.Ignore())
          .ForMember(dest => dest.DonateType, opt => opt.Ignore());

            CreateMap<PatientDocument, PatientDocument>()
         .ForMember(dest => dest.Id, opt => opt.Ignore())
         .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
         .ForMember(dest => dest.Patient, opt => opt.Ignore());

            CreateMap<OfflineCoronaTest, OfflineCoronaTest>()
         .ForMember(dest => dest.Id, opt => opt.Ignore())
         .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
         .ForMember(dest => dest.Patient, opt => opt.Ignore());

            CreateMap<Doctor, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImgUrl, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Specialization, opt => opt.Ignore())
                .ForMember(dest => dest.Agenda, opt => opt.Ignore())
                .ForMember(dest => dest.Chats, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorDocuments, opt => opt.Ignore());

            CreateMap<Agenda, Agenda>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.Doctor, opt => opt.Ignore());

            CreateMap<BloodType, BloodType>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.Patients, opt => opt.Ignore());

            CreateMap<DonateType, DonateType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Donations, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<Hospital, Hospital>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.City, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<Pharmacy, Pharmacy>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<CoronaStatus, CoronaStatus>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.OfflineCoronaTests, opt => opt.Ignore())
               .ForMember(dest => dest.OnlineCoronaTests, opt => opt.Ignore());

            CreateMap<Specialization, Specialization>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ImgUrl, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.Doctors, opt => opt.Ignore());


        }
    }
}
