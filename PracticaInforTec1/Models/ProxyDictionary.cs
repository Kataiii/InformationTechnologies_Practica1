using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace PracticaInforTec1.Models
{
    public class ProxyDictionary
    {
        public static Dictionary<string, string> loginsPasswords = new Dictionary<string, string>
        {
            { "login", "password" },
            { "admin", "123456" }
        };


        public static bool CheckedLogPas(string login, string password)
        {
            if (loginsPasswords.ContainsKey(login.ToLower()))
            {
                if (password.Equals(loginsPasswords[login.ToLower()])) return true;
            }
            return false;
        }
    }
}