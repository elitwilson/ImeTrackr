using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImeTrackr.Models
{
    public class Contact : Entity
    {
        public int OrganizationId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public ICollection<Plaintiff> Plaintiffs { get; set; }
        public ICollection<PhoneCall> PhoneCalls { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }

        public Organization Organization { get; set; }

        public string FullName {
            get { return FirstName + " " + LastName; }
        }
    }
}