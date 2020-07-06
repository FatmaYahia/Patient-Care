using System;

namespace PatientCare.Common
{
    public static class LocalCurrentTime
    {
        public static DateTime GetLocalCurrentLocation(string timeZone = "Egypt Standard Time")
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, timeZone);
        }
    }
}
