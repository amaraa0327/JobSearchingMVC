using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchTrackingMVC.Models
{
    public class ContactViewModel
    {
        public int ContactD { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}