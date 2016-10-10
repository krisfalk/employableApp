using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployableApp.Models
{
    public class CreateViewModel
    {

        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Job Experience 1")]
        public string JobExperienceOne { get; set; }
        [Display(Name = "Job Experience 2")]
        public string JobExperienceTwo { get; set; }
        [Display(Name = "Job Experience 3")]
        public string JobExperienceThree { get; set; }
        [Display(Name = "High School")]
        public string HighSchool { get; set; }
        public string College { get; set; }
        [Display(Name = "Other Schooling")]
        public string OtherSchooling { get; set; }
        public string Skills { get; set; }

        [Display(Name = "Reference 1")]
        public string ReferenceOne { get; set; }
        [Display(Name = "Reference 2")]
        public string ReferenceTwo { get; set; }
        [Display(Name = "Reference 3")]
        public string ReferenceThree { get; set; }
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }
        [Display(Name = "Apt./Unit Number(opt.)")]
        public string AptNumber { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

    }
}