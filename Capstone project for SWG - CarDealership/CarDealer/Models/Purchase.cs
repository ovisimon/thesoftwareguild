using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public DateTime Date { get; set; }
        public int PiecesSold { get; set; }
        public string User { get; set; }
    }
}