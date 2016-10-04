using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Skills { get; set; }
        public string References { get; set; }
    }
}