using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.Models
{
    public class PhoneCall : Entity
    {
        public int ContactId { get; set; }
        public int? PlaintiffId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime? Date { get; set; }        
        
        public string Message { get; set; }
        public bool IsComplete { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Plaintiff Plaintiff { get; set; }
    }
}