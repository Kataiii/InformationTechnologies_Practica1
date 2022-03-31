using PracticaInforTec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PracticaInforTec1.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [HttpGet]
        public ViewResult WebForm()
        {
            return View();
        }

        public ViewResult WebForm(string notCorrectForm)
        {
            ViewBag.Greeting = notCorrectForm;
            return View();
        }

        [HttpGet]
        public ActionResult GreatingAndSurvey()
        {
            return View();

        }

        public ActionResult UncorrectLogAndPas()
        {
            return View();
        }


        [HttpPost]
        public ViewResult WebForm(string login, string password)
        {
            if (ProxyDictionary.CheckedLogPas(Request.Form["login"], Request.Form["password"])) return View("GreatingAndSurvey");
            return WebForm("Incorrect password or login. Please try again.");
        }

        [HttpPost]
        public ViewResult GreatingAndSurvey(string[] form__listBox)
        {
            string form__listBoxStrr = "";
            if (form__listBox != null)
            {
                foreach (string word in form__listBox)
                {
                    form__listBoxStrr += word;
                    form__listBoxStrr += ", ";
                }
            }
            
            ViewBag.TextField = Request.Form["form__textField"];
            ViewBag.Form__listBoxDrinks = form__listBox != null ?
                form__listBoxStrr.Substring(0, form__listBoxStrr.Length-2) : form__listBoxStrr;
            ViewBag.Form__dpopDown = Request.Form["form__dpopDown"];
            ViewBag.Form__radio = Request.Form["example"];
            return View();
        }

        public ViewResult WebFormPractice2(List<string> values)
        {
            List<string> values_fields = new List<string>() { "", "", "", "" };
            if (values != null) values_fields = values;
            ViewBag.NoName = values_fields[0];
            ViewBag.SmallPassword = values_fields[1];
            ViewBag.NotCorrectRepPas = values_fields[2];
            return View();

        }

        [HttpPost]
        public ViewResult WebFormPractice2(string user_name, string password, string password_repeat)
        {
            List<string> values_fields = new List<string>() { "", "", "", "" };
            if (user_name == null || user_name == "") values_fields[0] = "Please fill in the field";
            if (password.Length < 8) values_fields[1] = "The password is too short";
            if (!password_repeat.Equals(password)) values_fields[2] = "Passwords don't match";
            return WebFormPractice2(values_fields);
        }

    }
}