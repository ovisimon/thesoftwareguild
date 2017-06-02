using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class MakeModel
    {
        public int MakeID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
    }
}