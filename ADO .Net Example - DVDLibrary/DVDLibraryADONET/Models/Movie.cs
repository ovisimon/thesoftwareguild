using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryADONET.Models
{
    public class Movie
    {
        public int DVDID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}