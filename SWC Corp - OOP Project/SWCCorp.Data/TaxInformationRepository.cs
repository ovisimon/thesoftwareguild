using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class TaxInformationRepository
    {
        private const string filePath = @".\Repositories\Taxes.txt";

        public List<TaxRate> GetRates()
        {
            List<TaxRate> rates = new List<TaxRate>();

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split('|');

                var rate = new TaxRate();

                rate.StateShort = columns[0];
                rate.State = columns[1];
                rate.Rate = decimal.Parse(columns[2]);

                rates.Add(rate);
            }
            return rates;
        }
    }
}
