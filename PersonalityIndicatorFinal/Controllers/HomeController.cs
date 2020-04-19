using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PersonalityIndicatorFinal.DbContext;
using PersonalityIndicatorFinal.Models;
using PersonalityIndicatorFinal.ViewModel;

namespace PersonalityIndicatorFinal.Controllers
{
    public class HomeController : Controller
    {
        public readonly PiDBContext _piDbContext = new PiDBContext();
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index()
        {
            var questionWithAnswers = new QuestionWithAnswers()
            {
                Questions = new List<Question>()
                {
                    new Question() {
                        QuestionNumber = 1, Questions = "You enjoy vibrant social events with lots of people." },//I-No E-yes
                    new Question() {
                        QuestionNumber = 2, Questions = "You would prefer to have one or two very intimate friends, without getting accquainted with very many people." },//I-yea E-no
                    new Question() {
                        QuestionNumber = 3, Questions = "You listen well and expect other to do the same" }, //I-yes E-no
                    new Question() {
                        QuestionNumber = 4, Questions = "You sometimes jump too quickly into an activities and don't allow enough time to think it over." }, //E-yes I-No
                    new Question() {
                        QuestionNumber = 5, Questions = "You feel comfortable in groups and like working" }, //E-yes I-No

                    new Question() {
                        QuestionNumber = 6, Questions = "You solve problems by working through facts until you understand the problem." },//S-yes N-No
                    new Question() {
                        QuestionNumber = 7, Questions = "You trust experiences first and trust words and symbols less." },//S-yes N-No
                    new Question() {
                        QuestionNumber = 8, Questions = "You think so much about new possibilities that you never look at how to make them a reality." },//S no N-yes
                    new Question() {
                        QuestionNumber = 9, Questions = "You like to see big picture, then to find out the facts." }, //S-no N-yes 
                    new Question() {
                        QuestionNumber = 10, Questions = "You remember events as snapshots of what actually happened." }, //S-yes N-no 

                    new Question() {
                        QuestionNumber = 11, Questions = "You look for logical explanations or solutions most everything." },//T-yes F-no
                    new Question() {
                        QuestionNumber = 12, Questions = "You make decisions with your heart and want to be compassionate." },//T-no f-yes
                    new Question() {
                        QuestionNumber = 13, Questions = "You look for what is important to others and express concern for others." },//T-no F-yes
                    new Question() {
                        QuestionNumber = 14, Questions = "You enjoy technical and scientific fields where logic is important." },//T-yes F-no
                    new Question() {
                        QuestionNumber = 15, Questions = "You believe telling truth is more important than being truthful." },//T-yes F-no

                    new Question() {
                        QuestionNumber = 16, Questions = "You appear to be task oriented." }, //J-yes P-no
                    new Question() {
                        QuestionNumber = 17, Questions = "You like to make lists of things to do." }, //J-yes P-no
                    new Question() {
                        QuestionNumber = 18, Questions = "You plan work to avoid rushing just before a deadline" }, //J-yes P-no
                    new Question() {
                        QuestionNumber = 19, Questions = "You work in bursts of energy." }, //J-no P-yes
                    new Question() {
                        QuestionNumber = 20, Questions = "You like to have things decided." }, //J-yes P-no
                }
            };

            foreach (var questionWithAnswer in questionWithAnswers.Questions)
            {
                questionWithAnswer.Answers = new List<Answer>()
                {
                    new Answer() {AnswerNumber = 2, Answers = "YES",},
                    new Answer() {AnswerNumber = 1, Answers = "Yes",},
                    new Answer() {AnswerNumber = 0, Answers = "Uncertain",},
                    new Answer() {AnswerNumber = -1, Answers = "No",},
                    new Answer() {AnswerNumber = -2, Answers = "NO",}
                };
            }
            return View(questionWithAnswers);
        }

        [HttpPost]
        [Route("Result")]
        public ActionResult AddAnswers()
        {
            var userAnswers = new UserAnswers();

            var length = Request.Form.Count;
            if (length < 20)
            {
                return RedirectToAction("Index");
            }
            var dataString = new List<string>();
            var data = new List<int>();

            foreach (var key in Request.Form.AllKeys)
                dataString.Add(Request.Form[key]);

            foreach (string s in dataString)
                data.Add(s.Contains("-") ? -((int)(s[s.Length-1]) - '0')  : (int)(s[s.Length-1]) - '0');

            var dictionary = new Dictionary<string, int>
            {
                {"I", 0}, {"E", 0}, {"S", 0}, {"N", 0}, {"T", 0}, {"F", 0}, {"J", 0}, {"P", 0}
            };
          
            var person = new Personality();
            var round = 1;
            foreach (var s in data)
            {
                if (round == 1 | round == 4 | round == 5)
                {
                    if (s == -1) dictionary["I"] += 1;
                    if (s == -2) dictionary["I"] += 2;
                    if (s == 1) dictionary["E"] += 1;
                    if (s == 2) dictionary["E"] += 2;
                }
                else if (round == 2 | round == 3)
                {
                    if (s == -1) dictionary["E"] += 1;
                    if (s == -2) dictionary["E"] += 2;
                    if (s == 1) dictionary["I"] += 1;
                    if (s == 2) dictionary["I"] += 2;
                }
                else if (round == 6 | round == 7 | round == 10)
                {
                    if (s == -1) dictionary["N"] += 1;
                    if (s == -2) dictionary["N"] += 2;
                    if (s == 1) dictionary["S"] += 1;
                    if (s == 2) dictionary["S"] += 2;
                }
                else if (round == 8 | round == 9)
                {
                    if (s == -1) dictionary["S"] += 1;
                    if (s == -2) dictionary["S"] += 2;
                    if (s == 1) dictionary["N"] += 1;
                    if (s == 2) dictionary["N"] += 2;
                }
                else if (round == 11 | round == 14 | round == 15)
                {
                    if (s == -1) dictionary["F"] += 1;
                    if (s == -2) dictionary["F"] += 2;
                    if (s == 1) dictionary["T"] += 1;
                    if (s == 2) dictionary["T"] += 2;
                }
                else if (round == 12 | round == 13)
                {
                    if (s == -1) dictionary["T"] += 1;
                    if (s == -2) dictionary["T"] += 2;
                    if (s == 1) dictionary["F"] += 1;
                    if (s == 2) dictionary["F"] += 2;
                }
                else if (round == 16 | round == 17 | round == 18 | round == 20)
                {
                    if (s == -1) dictionary["P"] += 1;
                    if (s == -2) dictionary["P"] += 2;
                    if (s == 1) dictionary["J"] += 1;
                    if (s == 2) dictionary["J"] += 2;
                }
                else if (round == 19)
                {
                    if (s == -1) dictionary["J"] += 1;
                    if (s == -2) dictionary["J"] += 2;
                    if (s == 1) dictionary["P"] += 1;
                    if (s == 2) dictionary["P"] += 2;
                }

                round++;
            }            

            if (dictionary["I"] >= dictionary["E"])
                person.personalityType += "I";
            else
                person.personalityType += "E";
            if (dictionary["N"] >= dictionary["S"])
                person.personalityType  += "N";
            else
                person.personalityType += "S";
            if (dictionary["F"] >= dictionary["T"])
                person.personalityType += "F";
            else
                person.personalityType += "T";
            if (dictionary["J"] >= dictionary["P"])
                person.personalityType += "J";
            else
                person.personalityType += "P";

            if (person.personalityType == "ISTJ") person.personality += "The Inspector";
            else if (person.personalityType == "ISTP") person.personality += "The Crafter";
            else if (person.personalityType == "ISFJ") person.personality += "The Protector";
            else if (person.personalityType == "ISFP") person.personality += "The Artist";

            else if (person.personalityType == "INFJ") person.personality += "The Advocate";
            else if (person.personalityType == "INFP") person.personality += "The Mediator";
            else if (person.personalityType == "INTJ") person.personality += "The Architect";
            else if (person.personalityType == "INTP") person.personality += "The Thinker";

            else if (person.personalityType == "ESTP") person.personality += "The Persuader";
            else if (person.personalityType == "ESTJ") person.personality += "The Director";
            else if (person.personalityType == "ESFP") person.personality += "The Performer";
            else if (person.personalityType == "ESFJ") person.personality += "The Caregiver";

            else if (person.personalityType == "ENFP") person.personality += "The Champion";
            else if (person.personalityType == "ENFJ") person.personality += "The Giver";
            else if (person.personalityType == "ENTP") person.personality += "The Debater";
            else if (person.personalityType == "ENTJ") person.personality += "The Commander";

            userAnswers.AnswerList = Request.Form.ToString();
            _piDbContext.UserAnswers.Add(userAnswers);
            _piDbContext.SaveChanges();

            return View(person);
        }

        public ActionResult About()
        {     
            return View();
        }

        public ActionResult Contact()
        {      
            return View();
        }
        [HttpPost]
        public ActionResult JobType()
        {
            var x = Request.Form;
            return View();
        }
    }
}