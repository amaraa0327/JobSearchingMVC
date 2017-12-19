using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearchTrackingMVC.Models
{
    public class FollowUp2ViewModel
    {
        public int JSTrackingID { get; set; }
        public string Type { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FollowUpDate { get; set; }
    }
}