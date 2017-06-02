using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class CarSearchModel
    {
        public string Term { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }
}