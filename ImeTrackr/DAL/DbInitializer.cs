using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImeTrackr.Models;

namespace ImeTrackr.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<ImeTrackrContext>
    {
        protected override void Seed(ImeTrackrContext context)
        {

            var organizations = new List<Organization>
            {
                new Organization { Name="Secrest Wardle", StAddress="94 Macomb Place", City="Mount Clemens", 
                    State="MI", Zip=48043 },
                new Organization { Name="B&B", StAddress="13jflsdf", City="Southfield", State="MI", Zip=23522 }
            };
            organizations.ForEach(o => context.Organizations.Add(o));
            context.SaveChanges();
            
            var evaluations = new List<Evaluation>
            {
                
            };
            evaluations.ForEach(e => context.Evaluations.Add(e));
            context.SaveChanges();

            var contacts = new List<Contact>
            {
                new Contact { FirstName="Bill", LastName="Bob", OrganizationId=1 },
                new Contact { FirstName="Joe", LastName="Ritard", OrganizationId=2 }
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

            

            var phoneCalls = new List<PhoneCall>
            {
            };
            phoneCalls.ForEach(p => context.PhoneCalls.Add(p));
            context.SaveChanges();
        }
    }
}