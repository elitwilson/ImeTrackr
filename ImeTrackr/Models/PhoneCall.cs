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

        public DateTime? Date { get; set; }
        
        public string Message { get; set; }

        public virtual Contact Contact { get; set; }
    }
}