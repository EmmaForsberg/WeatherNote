using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherNote.Models;

namespace WeatherNote.ViewModel
{
    public class NoteTempViewModel
    {
        public List<Models.WeatherNote> Notes { get; set; }
        public List<double> Temps { get; set; }
    }
}