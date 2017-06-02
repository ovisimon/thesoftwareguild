using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineMVC.Models
{
    public class ProductRepository
    {
        private static List<Product> _products;

        static ProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    Name = "Snickers",
                    Price = 1.50M,
                    Quantity = 10,
                },

                new Product
                {
                    ProductID = 2,
                    Name = "M&M's",
                    Price = 1.25M,
                    Quantity = 8,
                },

                new Product
                {
                    ProductID = 3,
                    Name = "Almond Joy",
                    Price = 1.25M,
                    Quantity = 11,
                },

                new Product
                {
                    ProductID = 4,
                    Name = "Milky Way",
                    Price = 1.65M,
                    Quantity = 3,
                },

                new Product
                {
                    ProductID = 5,
                    Name = "Payday",
                    Price = 1.75M,
                    Quantity = 2,
                },

                new Product
                {
                    ProductID = 6,
                    Name = "Reese's",
                    Price = 1.50M,
                    Quantity = 5,
                },

                new Product
                {
                    ProductID = 7,
                    Name = "Pringles",
                    Price = 2.35M,
                    Quantity = 4,
                },

                new Product
                {
                    ProductID = 8,
                    Name = "Cheezits",
                    Price = 2.00M,
                    Quantity = 6,
                },

                new Product
                {
                    ProductID = 9,
                    Name = "Doritos",
                    Price = 1.95M,
                    Quantity = 7,
                }
            };
        }

        public static IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public static Product Get(int productId)
        {
            var product = _products.FirstOrDefault(s => s.ProductID == productId);
            product.Quantity = product.Quantity - 1;
            return product;
        }
    }
}