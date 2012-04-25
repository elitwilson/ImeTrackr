using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImeTrackr.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.ViewModels
{
    public class PhoneCallViewModel
    {
        public int ContactId { get; set; }
        public int OrganizationId { get; set; }

        public IEnumerable<Plaintiff> Plaintiffs { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime Time { get; set; }

        [Required]
        public string Message { get; set; }
        
    }
}