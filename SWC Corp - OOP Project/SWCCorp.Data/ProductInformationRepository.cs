using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models
{
    public  class ProductInformationRepository
    {
        private const string filePath = @".\Repositories\Products.txt";

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split('|');

                var product = new Product();

                product.ProductType = columns[0];
                product.CostPerSquareFoot = decimal.Parse(columns[1]);
                product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                products.Add(product);
            }
            return products;
        }
    }
}
