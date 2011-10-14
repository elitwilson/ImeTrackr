using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImeTrackr.Models; 

namespace ImeTrackr.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ImeTrackrContext>
    {
        protected override void Seed(ImeTrackrContext context)
        {

            var organizations = new List<Organization>
            {
                new Organization { Name="N/A" }
            };
            organizations.ForEach(o => context.Organizations.Add(o));
            context.SaveChanges();

            //var contacts = new List<Contact>
            //{
            //    new Contact { FirstName="Bill", LastName="Bob", PhoneNumber="235-555-5555",
            //        OrganizationId=1, Evaluations = new List<Evaluation>() },
            //    new Contact { FirstName="Joe", LastName="Ritard", PhoneNumber="252-424-5743",
            //        OrganizationId=2, Evaluations = new List<Evaluation>()}
            //};
            //contacts.ForEach(c => context.Contacts.Add(c));
            //context.SaveChanges();
            
            //var plaintiffs = new List<Plaintiff>
            //{
            //    new Plaintiff { FirstName="Faker", LastName="McFakey", ContactId=1 },
            //    new Plaintiff { FirstName="Douche", LastName="McDoucherson", ContactId=1 },
            //    new Plaintiff { FirstName="Over", LastName="Dramatic", ContactId=2 }
            //};
            //plaintiffs.ForEach(p => context.Plaintiffs.Add(p));
            //context.SaveChanges();

            //var evaluations = new List<Evaluation>
            //{
            //    new Evaluation { CaseName="Blah", OrganizationId=1, PlaintiffId=1 },
            //    new Evaluation { CaseName="Argghghhh", OrganizationId=2, PlaintiffId=2 }
            //};
            //evaluations.ForEach(e => context.Evaluations.Add(e));
            //context.SaveChanges();

            //var phoneCalls = new List<PhoneCall>
            //{
            //    new PhoneCall { Message="Calling about blargh", ContactId=1 },
            //    new PhoneCall { Message="jlsdsdlkjglksh;a", ContactId=1 }
            //};
            //phoneCalls.ForEach(p => context.PhoneCalls.Add(p));
            //context.SaveChanges();

            //var techs = new List<Tech>
            //{
            //    new Tech { FirstName = "Eli", LastName = "Wilson", Initials = "EW" },
            //    new Tech { FirstName = "Bonnie", LastName = "Risveglia", Initials = "BR" }
            //};
            //techs.ForEach(t => context.Techs.Add(t));
            //context.SaveChanges();

            //contacts[1].Evaluations.Add(evaluations[1]);
        }
    }
}