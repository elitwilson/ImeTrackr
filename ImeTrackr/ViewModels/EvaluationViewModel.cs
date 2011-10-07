using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ImeTrackr.Models;

namespace ImeTrackr.ViewModels
{
    public class EvaluationViewModel : Entity
    {
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "DOB:")]
        public DateTime? DOB { get; set; }

        [Display(Name = "SSN:")]
        public int SSN { get; set; }

        [Display(Name = "Case Name:")]
        public string CaseName { get; set; }

        [Display(Name = "Case Number:")]
        public string CaseNumber { get; set; }

        [Display(Name = "Contact:")]
        public int ContactId { get; set; }
        public IEnumerable<SelectListItem> ContactSelectList { get; set; }

        [Display(Name = "Organization:")]
        public int OrganizationId { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectList { get; set; }
    }
}