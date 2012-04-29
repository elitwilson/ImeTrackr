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
                    new Organization { Id = 1, Name="Wilson & Wilson", StAddress = "", City = "", State = "", Zip = 15123, MainPhone = "", Fax = "" },
                    new Organization { Id = 2, Name="Zausmer & Kauffman", StAddress = "", City = "", State = "", Zip = 85439, MainPhone = "", Fax = "" },
                    new Organization { Id = 3, Name="Bowman & Brooke", StAddress = "", City = "", State = "", Zip = 52626, MainPhone = "", Fax = "" },
                    new Organization { Id = 4, Name="Plunkett & Cooney", StAddress = "", City = "", State = "", Zip = 35346, MainPhone = "", Fax = "" },
                    new Organization { Id = 5, Name="State Farm", StAddress = "", City = "", State = "", Zip = 42135, MainPhone = "", Fax = "" }
                };
            organizations.ForEach(o => context.Organizations.Add(o));
            context.SaveChanges();

            var contacts = new List<Contact>
                {
                    new Contact { Id=1, OrganizationId=3, FirstName="Bob", LastName="Jones", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" },
                    new Contact { Id=2, OrganizationId=3, FirstName="Steve", LastName="Burns", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" },
                    new Contact { Id=3, OrganizationId=2, FirstName="Jane", LastName="Doe", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" },
                    new Contact { Id=4, OrganizationId=4, FirstName="Stephanie", LastName="Stevens", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" },
                    new Contact { Id=5, OrganizationId=1, FirstName="Arlo", LastName="Wilkinson", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" },
                    new Contact { Id=6, OrganizationId=1, FirstName="Bubba", LastName="Roberts", PhoneNumber = "", JobTitle = "", Email = "", Notes = "" }
                };
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();

            var plaintiffs = new List<Plaintiff>
            {
                new Plaintiff { Id=1, FirstName="Bill", LastName="Jameson", SSN=1125},
                new Plaintiff { Id=2, FirstName="Henry", LastName="Ford", SSN=3246},
                new Plaintiff { Id=3, FirstName="Robert", LastName="Lee", SSN=1606},
                new Plaintiff { Id=4, FirstName="Abe", LastName="Lincoln", SSN=2364},
                new Plaintiff { Id=5, FirstName="George", LastName="Washington", SSN=0897},
                new Plaintiff { Id=6, FirstName="Barack", LastName="Obama", SSN=1234},
                new Plaintiff { Id=7, FirstName="Steve", LastName="Jobs", SSN=7228},
                new Plaintiff { Id=8, FirstName="Bill", LastName="Clinton", SSN=4956},
                new Plaintiff { Id=9, FirstName="Hillary", LastName="Clinton", SSN=6477},
                new Plaintiff { Id=10, FirstName="Nancy", LastName="Pelosi", SSN=3833},
                new Plaintiff { Id=11, FirstName="Jill", LastName="Jones", SSN=5479}
            };
            plaintiffs.ForEach(p => context.Plaintiffs.Add(p));
            context.SaveChanges();

            var techs = new List<Tech>
            {
                new Tech { Id=1, FirstName="Bonnie", LastName="Risveglia", Initials="BR" },
                new Tech { Id=2, FirstName="Amy", LastName="Guyton", Initials="AG" }
            };
            techs.ForEach(t => context.Techs.Add(t));
            context.SaveChanges();

            var phoneCalls = new List<PhoneCall>
            {
                new PhoneCall { Id=1, ContactId=1, PlaintiffId=1, Date=new DateTime(2011, 12, 1), Message="This is a message about Bill", IsComplete=false },
                new PhoneCall { Id=2, ContactId=1, PlaintiffId=2, Date=new DateTime(2012, 1, 1), Message="Test", IsComplete=false },
                new PhoneCall { Id=3, ContactId=2, PlaintiffId=2, Date=new DateTime(2012, 1, 4), Message="", IsComplete=false },
                new PhoneCall { Id=4, ContactId=4, PlaintiffId=3, Date=new DateTime(2011, 12, 17), Message="", IsComplete=false },
                new PhoneCall { Id=5, ContactId=5, PlaintiffId=4, Date=new DateTime(2011, 12, 30), Message="", IsComplete=true },
                new PhoneCall { Id=6, ContactId=6, PlaintiffId=5, Date=new DateTime(2012, 1, 10), Message="", IsComplete=false },
                new PhoneCall { Id=7, ContactId=3, PlaintiffId=5, Date=new DateTime(2012, 1, 10), Message="", IsComplete=false },
            };
            phoneCalls.ForEach(p => context.PhoneCalls.Add(p));
            context.SaveChanges();

            var evaluations = new List<Evaluation>
            {
                new Evaluation { Id=1, PlaintiffId=1, ContactId=1, TechId=1, DayOne = new DateTime(2012, 2, 5),  DayTwo = new DateTime(2012, 2, 6), Notes = "", CaseNumber="", CaseName="", IsComplete=false },
                new Evaluation { Id=2, PlaintiffId=1, ContactId=1, TechId=1, DayOne = new DateTime(2012, 1, 10), DayTwo = new DateTime(2012, 1, 11), Notes = "", CaseNumber="", CaseName="", IsComplete=true }, 
                new Evaluation { Id=3, PlaintiffId=2, ContactId=4, TechId=1, DayOne = new DateTime(2012, 1, 28), DayTwo = new DateTime(2012, 1, 29), Notes = "", CaseNumber="", CaseName="", IsComplete=false }, 
                new Evaluation { Id=4, PlaintiffId=3, ContactId=3, TechId=2, DayOne = new DateTime(2012, 2, 12), DayTwo = new DateTime(2012, 2, 13), Notes = "", CaseNumber="", CaseName="", IsComplete=false }, 
                new Evaluation { Id=5, PlaintiffId=4, ContactId=5, TechId=2, DayOne = new DateTime(2012, 2, 22), DayTwo = new DateTime(2012, 2, 23), Notes = "", CaseNumber="", CaseName="", IsComplete=false }
            };
            evaluations.ForEach(e => context.Evaluations.Add(e));

            //Make sure to set Evaluation.OrganizationId to Evaluation.Contact.OrganizationId
            foreach (var item in evaluations)
            {
                item.OrganizationId = item.Contact.OrganizationId;
            }

            context.SaveChanges();
        }
    }
}