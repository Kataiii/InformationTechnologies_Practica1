using PracticaInforTec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ActionResult RegistrationWebForm()
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
            ViewBag.Mail = values_fields[3];
            return View();

        }

        [HttpPost]
        public ViewResult WebFormPractice2(string user_name, string password, string password_repeat)
        {
            int flag = 0;
            string reg_expression = "^([a-z0-9_-]+\\.)*[a-z0-9_-]+@[a-z0-9_-]+(\\.[a-z0-9_-]+)*\\.[a-z]{2,6}$";
            List<string> values_fields = new List<string>() { "", "", "", "" };
            if (user_name == null || user_name == "")
            {
                flag = 1;
                values_fields[0] = "Please fill in the field";
            }
            if (password.Length < 8)
            {
                flag = 1;
                values_fields[1] = "The password is too short";
            }
            if (password_repeat==null|| String.IsNullOrWhiteSpace(password_repeat)|| !password_repeat.Equals(password))
            {
                flag = 1;
                values_fields[2] = "Passwords don't match";
            }
            if (!Regex.IsMatch(Request.Form["mail"], reg_expression))
            {
                flag = 1;
                values_fields[3] = "Email not correct";
            }
            if (flag == 0)
            {
                return View("RegistrationWebForm");
            }
            
            return WebFormPractice2(values_fields);
        }

        private string getLogSession()
        {
            var login = Session["login_session"];
            return login.ToString();
        }

        private string getPasSession()
        {
            var password = Session["password_session"];
            return password.ToString();
        }

        [HttpGet]
        public ViewResult RegistrationLabel()
        {
            
            ViewBag.LoginSession =getLogSession();
            ViewBag.PasswordSession = getPasSession();
            return View();
        }

       [HttpPost]
       public ViewResult RegistrationLabel(string login_session,string password_session)
        {
            Session["login_session"] = login_session;
            Session["password_session"] = password_session;
            bool isSessionNew = Session.IsNewSession;
            string sessionId = Session.SessionID;
            return RegistrationLabel();
        }

    }
}