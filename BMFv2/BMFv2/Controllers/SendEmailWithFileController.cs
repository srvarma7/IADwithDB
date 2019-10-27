using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BMFv2.Models;
using System.Net;
using System.Net.Mail;

using System.Threading.Tasks;

namespace BMFv2.Controllers
{
    public class SendEmailWithFileController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
        //Lecture Slides
        [HttpPost]
        public async Task<ActionResult> Send(SendEmailWithFileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                String receivers = model.FromName;
                //If there are multiple emails in the field it splits the emial and adds them to the list which stores all the emails
                List<String> toEmailList = receivers.Split(',').ToList();
                //If there are multiple emails, the mails are added to the message To list
                var message = new MailMessage();
                for (int i = 0;  i < toEmailList.Count(); i++)
                {
                    message.To.Add(new MailAddress(toEmailList.ElementAt<String>(i)));
                }
                //message.To.Add(new MailAddress("ckal0008@student.monash.edu")); 
                //message.To.Add(new MailAddress("srvarma7@gmail.com"));
                //message.To.Add(new MailAddress("shriyarox@gmail.com"));
                message.From = new MailAddress("ckal0008@student.monash.edu");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                //Checks if there is any file being selected.
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    //If selected it is being attached to the message.
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, System.IO.Path.GetFileName(model.Upload.FileName)));
                }

                using (var smtp = new SmtpClient())
                {
                    var credentials = new NetworkCredential
                    {
                        //username = "srvarma7@gmail.com"
                        //password = ""
                    };
                    smtp.Credentials = credentials;
                    smtp.Host = "smtp.monash.edu.au";
                    //smtp.Port = 80;
                    //smtp.EnableSsl = true;
                    ViewBag.Result = "Email has been send.";
                    await smtp.SendMailAsync(message);
                }
            }
            return RedirectToAction("Success");
        }
    }
}