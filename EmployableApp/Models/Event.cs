using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string StartDate { get; set; }

        public string Title { get; set; }

        public Boolean Editable { get; set; }
    }
}