using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace cryptography.Controllers
{
    public class HomeController : Controller
    {

        private string _publicKeyA ="";
        private string _privateKeyA = "";

        private string _publicKeyB = "";
        private string _privateKeyB = "";

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }


        public string encrypt(string ServerSymmetricKey, string AppPublicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
   
            byte[] cipherbytes;
            rsa.FromXmlString(AppPublicKey);

            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(ServerSymmetricKey), false);

            return Convert.ToBase64String(cipherbytes);
           
        }
    }
}
