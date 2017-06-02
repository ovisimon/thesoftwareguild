using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public int MakeID { get; set; }
        public string Make { get; set; }
        public int ModelID { get; set; }
        public string Model { get; set; }
        public string ImagePath { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }
        public decimal MSRP { get; set; }
        public int Year { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int TransmissionID { get; set; }
        public bool Featured { get; set; }
        public string BodyStyle { get; set; }
        public int BodyStyleID { get; set; }
        public string Color { get; set; }
        public int ColorID { get; set; }
        public int TypeID { get; set; }
        public int InteriorID { get; set; }
        public string Transmission { get; set; }
        public string Interior { get; set; }
    }
}