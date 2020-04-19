using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonalityIndicatorFinal.Models
{
    [Table("UserAnswers")]
    public class UserAnswers
    {
        [Key]
        public int AnswerKey { get; set; }
        public string UserName { get; set; }
        public string AnswerList { get; set; } = "";
    }
}