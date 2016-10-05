using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class StringToDateConverter
    {
        public DateTime convertToDateTime(string incomingData)
        {
            DateTime dateTime = DateTime.Parse(incomingData);
            return dateTime;
        }
    }
}