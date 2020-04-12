using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalityIndicatorFinal.Models
{
    public class Question
    {
        [Key]
        public int QuestionNumber { get; set; }
        public int ParticularQuestionNumber { get; set; }
        public string Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}