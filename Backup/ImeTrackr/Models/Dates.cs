using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImeTrackr.Models
{
    public class Dates
    {
        public DateTime AllDates(string date)
        {
            DateTime parsedDate;
            DateTime.TryParse(date, out parsedDate);

            return parsedDate;

        }
    }
}