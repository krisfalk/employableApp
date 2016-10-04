using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public bool AppliedFor { get; set; }
        public bool Favorite { get; set; }
        public string Posting_Link { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}