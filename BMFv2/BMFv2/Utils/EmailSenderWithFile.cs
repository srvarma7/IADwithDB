using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;


namespace BMFv2.Utils
{
    public class EmailSenderWithFile
    {
        /*
        public void Send(String toEmail, String subject, String contents, Fil)
        {
            MailMessage mail = new MailMessage(txtEmail.Text, txtTo.Text);//create MailMessage class object
            mail.Subject = txtSubject.Text;
            mail.Body = txtBody.Text;
            if (fuAttachment.HasFile)
            {
                string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                mail.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
            }
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();//Creating Smtp class objec
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential(txtEmail.Text, txtPassword.Text);//set Network Credential
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mail);
            //Response.Write("Send mail");
        }
        */
    }
}