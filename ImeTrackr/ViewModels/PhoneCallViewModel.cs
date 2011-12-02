using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImeTrackr.Models;
using System.ComponentModel.DataAnnotations;

namespace ImeTrackr.ViewModels
{
    public class PhoneCallViewModel : Entity
    {
        [Display(Name = "")]
        public string ContactName { get; set; }
    }
}