using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using System.Data;
using System.Windows.Forms;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EmployableApp.Models
{
    public class EmailReminder
    {
        string userID;
        private ApplicationDbContext db = new ApplicationDbContext();

        public void RunReminders(string userId)
        {
            userID = userId;

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000 * 60;// * //60 * //24;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        //Specify what you want to happen when the Elapsed event is raised.
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            var eventsList = (from a in db.Events where a.UserId == userID select a).ToList();
            var user = (from a in db.Users where a.Id == userID select a).FirstOrDefault();
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());


            foreach (var item in eventsList)
            {
                string Title = item.title;
                if (item.end == DateTime.Today || item.start == DateTime.Today)
                {
                   
                    //MessageBox.Show("Reminder. You have an event today: " + Title.ToString());

                    SendEmail sendEmail = new SendEmail();

                    string emailMsg = "Dear " + user.FirstName + " " + user.LastName + ",\r\n\r\nHere is your reminder for the " + Title.ToString() + " event. Please check our website.\r\nYou're welcome!! Please do not reply!!\r\n\r\nSincerely,\r\n.employable Team";
                    string emailAddr = "employable.app@gmail.com";

                    if (sendEmail.SendMail(emailAddr, user.Email, "Event Reminder from .employable", emailMsg, null))
                    {
                        MessageBox.Show("Reminder. You have an event today: " + Title.ToString() + ". Reminder email sent.");
                    }
                }
            }
            
        }


    }
}