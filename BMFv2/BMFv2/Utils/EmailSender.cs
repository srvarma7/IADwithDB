using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BMFv2.Utils
{
    public class EmailSender
    {

        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@bookmyflight.com", "BookMyFlight");
            var to = new EmailAddress(toEmail, "srvarma7@gmail.com");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            List<EmailAddress> toList = new List<EmailAddress>();
            toList.Add(new EmailAddress("srvarma7@gmail.com"));
            toList.Add(new EmailAddress("ckal0008@student.monash.edu"));
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var listmsg = MailHelper.CreateSingleEmailToMultipleRecipients(from, toList, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}