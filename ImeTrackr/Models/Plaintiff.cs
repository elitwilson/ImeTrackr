using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.Models
{
    public class Plaintiff : Entity
    {
        public int? ContactId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime? DOB { get; set; }
        public int SSN { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string LastFirst
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}