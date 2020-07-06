using System.Collections.Generic;

namespace PatientCare.App.Models
{
    public class CoronaTest
    {
        public CoronaTest()
        {
            Answers = new Dictionary<int, string>()
            {
                {1,"Yes" },
                {0,"No" }
            };
            notes = new List<string>();

        }

        public Dictionary<int, string> Answers { get; set; }
        public List<string> notes { get; set; }
        public string Question { get; set; }
        public int id { get; set; }
        public string ans { get; set; }
    }


    public class Result
    {
        public string ans { get; set; }
        public int id { get; set; }
    }
}
