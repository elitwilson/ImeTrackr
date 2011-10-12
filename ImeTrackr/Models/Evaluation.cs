using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.Models
{
    public class Evaluation : Entity
    {
        public int? PlaintiffId { get; set; }
        public int? OrganizationId { get; set; }
        
        public string       Notes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime?    DayOne { get; set; }

        public DateTime?    DateTwo { get; set; }
        public string       CaseNumber { get; set; }
        public string       CaseName { get; set; }

        public virtual Plaintiff Plaintiff { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}