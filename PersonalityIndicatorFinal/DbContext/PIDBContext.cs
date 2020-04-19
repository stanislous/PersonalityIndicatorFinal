using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PersonalityIndicatorFinal.Models;

namespace PersonalityIndicatorFinal.DbContext
{
    public class PiDBContext:System.Data.Entity.DbContext
    {
        public DbSet<UserAnswers> UserAnswers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}