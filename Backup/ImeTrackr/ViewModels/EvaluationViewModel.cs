using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ImeTrackr.Models;

namespace ImeTrackr.ViewModels
{
    public class EvaluationViewModel
    {
        public int PlaintiffId { get; set; }
        public int EvaluationId { get; set; }

        public Evaluation Evaluation { get; set; }
        public Plaintiff Plaintiff { get; set; }
        public Contact Contact { get; set; }
        public Organization Organization { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Plaintiff> Plaintiffs { get; set; }
        public IEnumerable<Tech> Techs { get; set; }

        //[Display(Name = "Contact:")]
        public int ContactId { get; set; }
        public IEnumerable<SelectListItem> ContactSelectList { get; set; }

        [Display(Name = "Organization:")]
        public int OrganizationId { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectList { get; set; }

        [Display(Name = "Technician:")]
        public int TechId { get; set; }
        public IEnumerable<SelectListItem> TechSelectList { get; set; }
    }
}