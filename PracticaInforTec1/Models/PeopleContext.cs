using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PracticaInforTec1.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}