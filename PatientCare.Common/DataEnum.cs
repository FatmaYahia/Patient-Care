namespace PatientCare.Common
{
    public static class AppMainData
    {
        public static string WebRootPath { get; set; }
        public static string DomainName { get; set; }

    }
    public class DataEnum
    {
        public enum AccessLevelEnum
        {
            FullAccess = 1,
            ControlAccess = 2,
            ViewAccess = 3
        };
        public enum SystemViewEnum
        {
            Home = 1,
            SystemView = 2,
            SystemUser = 3
        };

        public enum GenderEnum
        {
            Male = 1,
            Female = 2
        };
        public enum SpecializationEnum
        {
            Cardiology = 1,
            Nutrition = 2,
            Psychiatry = 3,
            Pulmonologist = 4,
            Nephrology = 5,
            Pediatrics = 6,
            InternalMedicine = 7,
            Deratology = 8
        };

        public enum BloodTypeEnum
        {
            APos = 1,
            BPos = 2,
            OPos = 3,
            ABPos = 4,
            ANeg = 5,
            BNeg = 6,
            ONeg = 7,
            ABNeg = 8
        };

        public enum DonateTypeEnum
        {
            BloodCells = 1,
            Platelets = 2,
            Plasma = 3
        };


        public enum CoronaStatusEnum
        {
            Positive = 1,
            Negative = 2,
            Low = 3,
            Moderate = 4,
            Severe = 5
        };
    }
}
