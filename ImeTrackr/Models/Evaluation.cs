using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.Models
{
    public class Evaluation : Entity
    {
        public string Notes { get; set; }
        public DateTime? DayOne { get; set; }
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        
        public virtual Plaintiff Plaintiff { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}