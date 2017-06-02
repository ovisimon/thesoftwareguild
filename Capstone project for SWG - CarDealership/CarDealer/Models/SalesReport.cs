using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class SalesReport
    {
        public string User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}