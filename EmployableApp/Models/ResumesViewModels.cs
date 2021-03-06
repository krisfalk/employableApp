﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace EmployableApp.Models
{
    public class CreateViewModel
    {

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Job 1")]
        public string JobExperienceOne { get; set; }
        [Display(Name = "Job 2")]
        public string JobExperienceTwo { get; set; }
        [Display(Name = "Job 3")]
        public string JobExperienceThree { get; set; }
        [Display(Name = "High School")]
        public string HighSchool { get; set; }
        public string College { get; set; }
        [Display(Name = "Other Schooling")]
        public string OtherSchooling { get; set; }
        public string Skills { get; set; }

        [Display(Name = "Ref. 1")]
        public string ReferenceOne { get; set; }
        [Display(Name = "Ref. 2")]
        public string ReferenceTwo { get; set; }
        [Display(Name = "Ref. 3")]
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