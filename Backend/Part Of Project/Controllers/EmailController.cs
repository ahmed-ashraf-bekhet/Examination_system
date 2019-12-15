using Part_Of_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;


namespace Part_Of_Project.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]
        public IHttpActionResult postmail(Email em)
        {
            //return Ok();
            string subject = em.subject;
            string body = em.body;
            string to = em.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("ahemdashrafhero@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ahmedashrafhero@gmail.com",
                Password = "Ahmed0227693223"
            };
            smtp.Send(mm);
            return Ok();

        }
    }
}
