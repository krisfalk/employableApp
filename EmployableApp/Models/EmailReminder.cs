using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using System.Data;
using System.Windows.Forms;


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


            foreach (var item in eventsList)
            {
                string Title = item.title;
                if (item.end == DateTime.Today || item.start == DateTime.Today)
                {
                   
                    MessageBox.Show("Reminder. You have an event today: " + Title.ToString());
                    //send email reminder
                    //pop up alert on page
                }
            }
            
        }


    }
}