using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public Boolean allDay { get; set; }

        public string title { get; set; }

        public Boolean editable { get; set; }
    }
}