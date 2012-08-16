using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImeTrackr.Models;

namespace ImeTrackr.ViewModels
{
    public class OrganizationDetailsVM
    {
        public Organization Organization { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Evaluation> Evaluations { get; set; }
    }
}