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
                new Organization { Name="Secrest Wardle", StAddress="94 Macomb Place", City="Mount Clemens", 
                    State="MI", Zip=48043, MainPhone="242-444-1212" },
                new Organization { Name="B&B", StAddress="13jflsdf", City="Southfield", State="MI", Zip=23522,
                    MainPhone="355-232-1555"}
            };
            organizations.ForEach(o => context.Organizations.Add(o));
            context.SaveChanges();

            var contacts = new List<Contact>
            {
                new Contact { FirstName="Bill", LastName="Bob", PhoneNumber="235-555-5555",
                    OrganizationId=1, Evaluations = new List<Evaluation>() },
                new Contact { FirstName="Joe", LastName="Ritard", PhoneNumber="252-424-5743",
                    OrganizationId=2, Evaluations = new List<Evaluation>()}
            };
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
            
            var plaintiffs = new List<Plaintiff>
            {
                new Plaintiff { FirstName="Faker", LastName="McFakey", ContactId=1 },
                new Plaintiff { FirstName="Douche", LastName="McDoucherson", ContactId=1 },
                new Plaintiff { FirstName="Over", LastName="Dramatic", ContactId=2 }
            };
            plaintiffs.ForEach(p => context.Plaintiffs.Add(p));
            context.SaveChanges();

            var evaluations = new List<Evaluation>
            {
                new Evaluation { CaseName="Blah", OrganizationId=1, PlaintiffId=1 },
                new Evaluation { CaseName="Argghghhh", OrganizationId=2, PlaintiffId=2 }
            };
            evaluations.ForEach(e => context.Evaluations.Add(e));
            context.SaveChanges();

            var phoneCalls = new List<PhoneCall>
            {
                new PhoneCall { Message="Calling about blargh", ContactId=1 },
                new PhoneCall { Message="jlsdsdlkjglksh;a", ContactId=1 }
            };
            phoneCalls.ForEach(p => context.PhoneCalls.Add(p));
            context.SaveChanges();

            contacts[1].Evaluations.Add(evaluations[1]);
        }
    }
}