using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImeTrackr.Models
{
    public class Organization : Entity
    {
        public string Name { get; set; }
        public string StAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int    Zip { get; set; }
        public string MainPhone { get; set; }
        public string Fax { get; set; }
        

        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}