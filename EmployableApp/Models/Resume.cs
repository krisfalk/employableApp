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
        public string JobExperienceOne { get; set; }

        public string JobExperienceTwo { get; set; }

        public string JobExperienceThree { get; set; }
        public string HighSchool { get; set; }
        public string College { get; set; }
        public string OtherSchooling { get; set; }
        public string Skills { get; set; }
        public string ReferenceOne { get; set; }
        public string ReferenceTwo { get; set; }
        public string ReferenceThree { get; set; }


    }
}