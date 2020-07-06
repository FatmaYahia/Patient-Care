using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PatientCare.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace PatientCare.App.Controllers
{
    public class CoronaController : Controller
    {
        #region
        public static List<CoronaTest> CoronaTestList = new List<CoronaTest>()
        {
            new CoronaTest(){Question="Do you have a cough?" ,id=1 },
            new CoronaTest(){Question="Are you having difficulty breathing?",id=2  },
            new CoronaTest(){Question="Do you have a fever?" ,id=3 },
            new CoronaTest(){Question="How severe are your symptoms?\n\n\nSeverity is defined as:" ,id=4 , Answers=new Dictionary<int, string>(){ { 0,"None" },{1, "Mild" },{ 2, "Moderate" },{ 3, "Severe" } },
            notes=new List<string>(){"None: There is no coughing, difficulty breathing, or feverish." ,
                "Mild: Easy to breathe, no wheezing, usual activities (such as walking around the house) are not affected. Coughing is mild. You may have: runny nose, sore throat, body aches, or a mild fever (from 37.3℃ to less than 39.5℃). You may feel tired." ,
                "Moderate: Mild wheezing, some chest tightness, beginning to affect activities such as working, sleeping, or playing. Coughing may make you feel slightly out of breath, but you can catch your breath easily when you stop coughing. You may have: runny nose, sore throat, body aches, or a mild fever (from 37.3℃ to less than 39.5℃)." ,
                "Severe: Interruption of usual activities, such as difficulty talking, eating, or walking. Breathing may be hard and fast. You may see bluish coloration in lips or fingertips. You feel persistent pressure in the chest, which might worsen with breathing. You may see ribs while breathing, feel lethargic or confused. Your temperature may be 39.5℃ or higher." }
                },
            new CoronaTest(){Question="Do you believe you may have been exposed to someone with COVID-19?",id=5,
            notes=new List<string>(){"Risk of exposure may occur under the following circumstances:" ,
                "There is an ongoing community spread of the virus in your local area or an area that you traveled to within 14 days of symptom onset" ,
                "You are a healthcare worker who has cared for a person with a suspected or confirmed diagnosis of COVID-19 within 14 days of symptom onset" ,
                "You have been in close contact with a person with a confirmed diagnosis of COVID-19" } },

            new CoronaTest(){Question="Are you over the age of 65?" ,id=6},
            new CoronaTest(){Question="Do you have a history of diabetes?" ,id=7 },

            new CoronaTest(){Question="Do you have a history of cardiovascular or heart disease?" ,id=8,
            notes=new List<string>(){"Answer yes to this question if any of the following are true:","You have a history of prior heart attack, stroke, or heart failure"} },

            new CoronaTest(){Question="Do you have a history of decreased immunity?" ,id=9,
            notes=new List<string>(){"Answer yes to this question if any of the following are true:\n\n" +
                "You take long-term oral steroids" ,
                "You have an autoimmune disease such as lupus or rheumatoid arthritis" ,
                "You have a history of cancer" ,
                "You have HIV/AIDS" ,
                "You have chronic kidney or liver disease" ,
                "You are on medications after an organ transplant" ,
                "Your doctor has told you that your medications may cause decreased immunity or has told you that you have decreased immunity for reasons not listed above"} },
            new CoronaTest(){Question="Are you pregnant?" ,id=11},
            new CoronaTest(){Question="Do you have a history of chronic lung disease?" ,id=11,
            notes= new List<string>(){"Answer yes to this question if any of the following are true:" ,
                "You have a history of asthma" ,
                "You have a history of chronic obstructive pulmonary disease/copd or emphysema" ,
                "You have a history of chronic bronchitis" ,
                "You have a history of interstitial lung disease" ,
                "You have a history of a chronic lung disease not listed above"} },
        };
        public static int Qno = -1;
        #endregion
        public static List<Result> getResult = new List<Result>();
        public IActionResult Advice()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CoronaAssessment()
        {
            Qno = -1;
            getResult = new List<Result>();
            return View();
        }
        [HttpPost]
        public IActionResult CoronaAssessment(CoronaTest coronaTest)
        {
            if (Qno < CoronaTestList.Count - 1)
            {
                if (coronaTest.id == -1)
                {
                    Qno--;
                }
                else
                {
                    Qno++;
                }
                getResult.Add(new Result() { id = coronaTest.id, ans = coronaTest.ans });
                ViewBag.Qno = Qno;
                ViewBag.Questions = CoronaTestList[Qno];


            }

            else
            {
                if (getResult.Any(n => n.id == 3 && n.ans == "Yes") && getResult.Any(n => n.id == 4 && n.ans == "Severe"))
                {
                    ViewBag.result = "Risk";
                }

                else if (getResult.Any(n => n.id == 5 && n.ans == "Yes"))
                {
                    ViewBag.result = "Elevated";
                }
                else
                {
                    ViewBag.result = "Low";
                }
            }

            return PartialView("_CoronaAssessment");
        }

    }
}
