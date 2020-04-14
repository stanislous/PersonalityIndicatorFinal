using System;
using System.Collections.Generic;

namespace PersonalityIndicatorFinal.Models
{
    public class Question
    {
        public int QuestionNumber { get; set; }
        public string Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}