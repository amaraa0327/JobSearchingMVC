using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobSearchTrackingMVC.Models
{
    public class JSTrackingViewModel
    {
        [Display(Name = "Job Information")]
        public int JSTrackingID { get; set; }
        //public int CompanyID { get; set; }
        //public int LocationID { get; set; }
        //public int ContactID { get; set; }

        [DataType(DataType.MultilineText)]
        public string JobDescription { get; set; }
        public string SourcePosting { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ResumeDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InterviewDateTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        public CompanyViewModel Company { get; set; }
        public LocationViewModel Location { get; set; }
        public ContactViewModel Contact { get; set; }
        public FollowUp1ViewModel FollowUp1 { get; set; }
        public FollowUp2ViewModel FollowUp2 { get; set; }
    }
}