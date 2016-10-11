using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using EmployableApp.Models;

namespace EmployableApp.Models
{
    public class EmailReminder
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void RunReminders()
        {
         
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 500000000;
            aTimer.Enabled = true;

       
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (var item in db.Events)
            {

            }

        }


    }
}