using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ImeTrackr.Models;
using ImeTrackr.ViewModels;

namespace ImeTrackr.Models
{
    public class ImeTrackrContext : DbContext
    {


        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Plaintiff> Plaintiffs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PhoneCall> PhoneCalls { get; set; }

        public DbSet<EvaluationViewModel> EvaluationViewModels { get; set; }
    }
}