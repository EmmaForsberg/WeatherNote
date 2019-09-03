using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherNote.Models
{
    public class WeatherNote
    {
        public int WeatherNoteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string Message { get; set; }
    }
}