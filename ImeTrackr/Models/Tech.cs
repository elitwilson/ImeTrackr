using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImeTrackr.Models
{
    public class Tech : Entity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public string FullName 
        {
            get { return FirstName + " " + LastName; }
        }
    }
}