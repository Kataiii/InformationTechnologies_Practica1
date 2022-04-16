using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaInforTec1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RewardId { get; set; }
        public Reward reward { get; set; }
    }
}