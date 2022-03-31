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
            foreach (string word in form__listBox)
            {
                form__listBoxStrr += word;
                form__listBoxStrr += ", ";
            }
            ViewBag.TextField = Request.Form["form__textField"];
            ViewBag.Form__listBoxDrinks = form__listBoxStrr.Substring(0, form__listBoxStrr.Length-2); ;
            ViewBag.Form__dpopDown = Request.Form["form__dpopDown"];
            ViewBag.Form__radio = Request.Form["example"];
            return View();
        }

    }
}