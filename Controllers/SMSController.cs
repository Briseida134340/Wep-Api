using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class SMSController : Controller
    {
        // Recibe tipo User
        public JsonResult Get()
        {
            string accountSid = "ACd5ac0fc67b1174e43a89c06a182c659d";
            string authToken = "2245733cb3620b7044a3cb62a93dbc06";

            TwilioClient.Init(accountSid, authToken);
            //generar codigo aleteorio.


            Random r = new Random();
            int codigo = r.Next(1, 999);


            var message = MessageResource.Create(
                body: codigo.ToString(),
                from: new Twilio.Types.PhoneNumber("+1 864 664 3693"),
                to: new Twilio.Types.PhoneNumber("") // Recuperar Telefono de usuario

            );
            return Json(codigo.ToString(),JsonRequestBehavior.AllowGet);
        }

    }
}