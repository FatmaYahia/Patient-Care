using Microsoft.EntityFrameworkCore;
using PatientCare.Common;
using PatientCare.Entity.AppModel;
using PatientCare.Entity.AuthModel;
using static PatientCare.Common.DataEnum;

namespace PatientCare.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<CoronaStatus> CoronaStatuses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorDocument> DoctorDocuments { get; set; }
        public DbSet<DonateType> DonateTypes { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OfflineCoronaTest> OfflineCoronaTests { get; set; }
        public DbSet<OnlineCoronaTest> OnlineCoronaTests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDocument> PatientDocuments { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SystemUserPermission> SystemUserPermission { get; set; }
        public DbSet<SystemView> SystemView { get; set; }
        public DbSet<AccessLevel> AccessLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>()
         .HasData(
             new AccessLevel
             {
                 Id = (int)AccessLevelEnum.FullAccess,
                 Name = "FullAccess",
             },
             new AccessLevel
             {
                 Id = (int)AccessLevelEnum.ControlAccess,
                 Name = "ControlAccess",
             },
             new AccessLevel
             {
                 Id = (int)AccessLevelEnum.ViewAccess,
                 Name = "ViewAccess",
             }
         );

            modelBuilder.Entity<SystemView>()
            .HasData(
                new SystemView
                {
                    Id = (int)SystemViewEnum.Home,
                    Name = "Home",
                },
                new SystemView
                {
                    Id = (int)SystemViewEnum.SystemView,
                    Name = "SystemView",
                },
                new SystemView
                {
                    Id = (int)SystemViewEnum.SystemUser,
                    Name = "SystemUser",
                }
            );

            modelBuilder.Entity<Gender>()
                .HasData(
                new Gender
                {
                    Id = (int)GenderEnum.Male,
                    Name = "Male",
                },
                 new Gender
                 {
                     Id = (int)GenderEnum.Female,
                     Name = "Female",
                 }
               );
            modelBuilder.Entity<BloodType>()
               .HasData(
               new BloodType
               {
                   Id = (int)BloodTypeEnum.APos,
                   Name = "A+",
               },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.BPos,
                    Name = "B+",
                },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.OPos,
                    Name = "O+",
                },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.ABPos,
                    Name = "AB+",
                },
                 new BloodType
                 {
                     Id = (int)BloodTypeEnum.ANeg,
                     Name = "A-",
                 },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.BNeg,
                    Name = "B-",
                },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.ONeg,
                    Name = "O-",
                },
                new BloodType
                {
                    Id = (int)BloodTypeEnum.ABNeg,
                    Name = "AB-",
                }
              );
            modelBuilder.Entity<DonateType>()
                   .HasData(
                  new DonateType
                  {
                      Id = (int)DonateTypeEnum.BloodCells,
                      Name = "BloodCells",
                  },
                 new DonateType
                 {
                     Id = (int)DonateTypeEnum.Platelets,
                     Name = "Platelets",
                 },
                 new DonateType
                 {
                     Id = (int)DonateTypeEnum.Plasma,
                     Name = "Plasma",
                 }
              );
            modelBuilder.Entity<Specialization>()
              .HasData(
              new Specialization
              {
                  Id = (int)SpecializationEnum.Cardiology,
                  Name = "Cardiology",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Nutrition,
                  Name = "Nutrition",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Psychiatry,
                  Name = "Psychiatry",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Pulmonologist,
                  Name = "Pulmonologist",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Nephrology,
                  Name = "Nephrology",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Pediatrics,
                  Name = "Pediatrics",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.InternalMedicine,
                  Name = "Internal Medicine",
              },
              new Specialization
              {
                  Id = (int)SpecializationEnum.Deratology,
                  Name = "Deratology",
              }
             );

            modelBuilder.Entity<CoronaStatus>()
               .HasData(
               new CoronaStatus
               {
                   Id = (int)CoronaStatusEnum.Positive,
                   Name = "Positive",
               },
                new CoronaStatus
                {
                    Id = (int)CoronaStatusEnum.Negative,
                    Name = "Negative",
                },
                 new CoronaStatus
                 {
                     Id = (int)CoronaStatusEnum.Low,
                     Name = "Low",
                 }, new CoronaStatus
                 {
                     Id = (int)CoronaStatusEnum.Moderate,
                     Name = "Moderate",
                 }, new CoronaStatus
                 {
                     Id = (int)CoronaStatusEnum.Severe,
                     Name = "Severe",
                 }
              );
            modelBuilder.Entity<SystemUser>()
             .HasData(
                 new SystemUser
                 {
                     Id = 1,
                     Email = "Developer@App.com",
                     FullName = "Developer",
                     JopTitle = "Developer",
                     Password = RandomGenerator.RandomKey(),
                     IsActive = true,
                 }
             );
            modelBuilder.Entity<SystemUserPermission>()
            .HasData(
                new SystemUserPermission
                {
                    Id = 1,
                    Fk_SystemUser = 1,
                    Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                    Fk_SystemView = (int)SystemViewEnum.Home,
                },
                new SystemUserPermission
                {
                    Id = 2,
                    Fk_SystemUser = 1,
                    Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                    Fk_SystemView = (int)SystemViewEnum.SystemView,
                },
                new SystemUserPermission
                {
                    Id = 3,
                    Fk_SystemUser = 1,
                    Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                    Fk_SystemView = (int)SystemViewEnum.SystemUser,
                }
            );

        }
    }
}
