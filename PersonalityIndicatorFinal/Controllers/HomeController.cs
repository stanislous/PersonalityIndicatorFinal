using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalityIndicatorFinal.Models;
using PersonalityIndicatorFinal.ViewModel;

namespace PersonalityIndicatorFinal.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            var questionWithAnswers = new QuestionWithAnswers()
            {
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        QuestionNumber = 1, Questions = "How old are you?",
                        Answers = new List<Answer>()
                        {
                            new Answer() {AnswerNumber = 1, Answers = "12",},
                            new Answer() {AnswerNumber = 2, Answers = "23",},
                            new Answer() {AnswerNumber = 3, Answers = "28",},
                            new Answer() {AnswerNumber = 4, Answers = "35",}
                        }
                    },
                    new Question()
                    {
                        QuestionNumber = 2, Questions = "what is your name?",
                        Answers = new List<Answer>()
                        {
                            new Answer() {AnswerNumber = 1, Answers = "hasith",},
                            new Answer() {AnswerNumber = 2, Answers = "nimal",},
                            new Answer() {AnswerNumber = 3, Answers = "kamal",},
                            new Answer() {AnswerNumber = 4, Answers = "sunil",}
                        }
                    }
                }
            };

            return View(questionWithAnswers);
        }
        [HttpPost]
        public ActionResult AddAnswers(NewAnswers newAnswers)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}