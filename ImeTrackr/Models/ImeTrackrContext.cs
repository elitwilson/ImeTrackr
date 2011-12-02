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
        public DbSet<Tech> Techs { get; set; }

        public DbSet<EvaluationViewModel> EvaluationViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /* Code First configures cascade delete on required relationships by default.
            * In this app, CascadeOnDelete needs to be switched to "false" for phone call in order
            * to prevent a Cyclical Reference Error. */
            modelBuilder.Entity<Contact>()
                .HasRequired(e => e.Organization)
                .WithMany()
                .HasForeignKey(e => e.OrganizationId).WillCascadeOnDelete(false);
        }
    }


}