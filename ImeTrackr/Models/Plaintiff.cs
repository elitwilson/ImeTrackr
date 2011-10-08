﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.Models
{
    public class Plaintiff : Entity
    {
        public int ContactId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int SSN { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
        
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}