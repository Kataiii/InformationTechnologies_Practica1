using PracticaInforTec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PracticaInforTec1.Controllers
{
    public class Practice2WebFormController : HomeController
    {
        /*public ViewResult WebFormPractice2()
        {
            return View();
        }*/

        [HttpGet]
        public ViewResult WebFormPractice2(List<string> values)
        {
            List<string> values_fields = new List<string>() { "", "", "", "" };
            if (values != null) values_fields = values;
            ViewBag.NoName = values_fields[0];
            ViewBag.SmallPassword = values_fields[0];
            ViewBag.NotCorrectRepPas = values_fields[0];
            return View();

        }

        [HttpPost]
        public ViewResult WebFormPractice2(string user_name, string password, string password_repeat)
        {
            List<string> values_fields = new List<string>() { "", "", "", "" };
            if (user_name == null || user_name == "") values_fields[0] = "Please fill in the field";
            if (password.Length < 8) values_fields[0] = "The password is too short";
            if (password_repeat.Equals(password)) values_fields[0] = "Passwords don't match";
            return WebFormPractice2(values_fields);
        }
    }
}