using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EmployableApp
{
    public class SendEmail
    {
        public SendEmail()
        {

        }
        public bool SendMail(string strFrom, string strTo, string strSubject, string strMsg, Attachment at)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(strFrom);
                mail.To.Add(strTo);
                mail.Subject = strSubject;
                mail.Body = strMsg;
                if(at != null)
                //Attachment at = new Attachment(System.Web.HttpContext.Current.Server.MapPath("~/resumeKRIS.docx"));
                    mail.Attachments.Add(at);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("employable.app", "employable");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}