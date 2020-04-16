using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalityIndicatorFinal.Models;
using PersonalityIndicatorFinal.ViewModel;

namespace PersonalityIndicatorFinal.Controllers
{
    public class HomeController : Controller
    {
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
                        QuestionNumber = 1, Questions = "You are almost never late your appointments" },
                    new Question() {
                        QuestionNumber = 2, Questions = "You spend your leisure time activity socializing with a group of people, attending parties, shopping etc." }, 
                    new Question() {
                        QuestionNumber = 3, Questions = "The most people you speak to, the better you feel." },
                    new Question() {
                        QuestionNumber = 4, Questions = "For you, it is easier to gain knowledge through hands-on experience than from books or manuals." },
                    new Question() {
                        QuestionNumber = 5, Questions = "You enjoy vibrant social events with lots of people." },
                    new Question() {
                        QuestionNumber = 6, Questions = "If your friend is sad about something, your first instinct is to support them emotionally, not try to solve their problem." },
                    new Question() {
                        QuestionNumber = 7, Questions = "You are still bothered by the mistakes you made a long time ago." },
                    new Question() {
                        QuestionNumber = 8, Questions = "You often make decisions on a whim." },
                    new Question() {
                        QuestionNumber = 9, Questions = "You always know exactly what you want." },
                    new Question() {
                        QuestionNumber = 10, Questions = "You look after your self first, and other come in second." },
                    new Question() {
                        QuestionNumber = 11, Questions = "Your mood can change very quickly." },
                    new Question() {
                        QuestionNumber = 12, Questions = "You always consider how your actions might affect other people before doing something." },
                    new Question() {
                        QuestionNumber = 13, Questions = "You dislike being in competition with others." },
                    new Question() {
                        QuestionNumber = 14, Questions = "You try to avoid conflict." }
                }
            };

            foreach (var questionWithAnswer in questionWithAnswers.Questions)
            {
                questionWithAnswer.Answers = new List<Answer>()
                {
                    new Answer() {AnswerNumber = 1, Answers = "YES",},
                    new Answer() {AnswerNumber = 2, Answers = "Yes",},
                    new Answer() {AnswerNumber = 3, Answers = "Uncertain",},
                    new Answer() {AnswerNumber = 3, Answers = "No",},
                    new Answer() {AnswerNumber = 4, Answers = "NO",}
                };
            }
            return View(questionWithAnswers);
        }
        [HttpPost]
        public ActionResult AddAnswers()
        {
            var data = Request.Form;

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