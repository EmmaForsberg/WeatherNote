using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherNote.Models
{
    public class WeatherNote
    {
        public int WeatherNoteId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}