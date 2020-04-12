using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PersonalityIndicatorFinal.Models;

namespace PersonalityIndicatorFinal.DbContext
{
    public class MyDBContext : System.Data.Entity.DbContext
    {
        public MyDBContext()
        {

        }

        public DbSet<Question> Questions { get; set; }
    }
}