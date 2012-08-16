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
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime Date { get; set; }

        public string PlaintiffFirstName { get; set; }
        public string PlaintiffLastName {get;set;}
        public string ContactFirstName {get;set;}
        public string ContactLastName { get; set; }
        public string Message { get; set; }

        public List<ContactMatch> ContactMatches { get; set; }
        public List<PlaintiffMatch> PlaintiffMatches { get; set; }
        
        public class ContactMatch
        {

            public int Id { get; set; }
            public string FullName { get; set; }
        }


        public class PlaintiffMatch
        {
            public int Id { get; set; }
            public string FullName { get; set; }
        }


        //public int ContactId { get; set; }
        //public int OrganizationId { get; set; }

        //public IEnumerable<Plaintiff> Plaintiffs { get; set; }
        //public IEnumerable<Organization> Organizations { get; set; }
        //public IEnumerable<Contact> Contacts { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        //public DateTime Date { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        //public DateTime Time { get; set; }

        //[Required]
        //public string Message { get; set; }


    }

}