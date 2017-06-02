using SWCCorp.Data;
using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            ProductInformationRepository prodRepo = new ProductInformationRepository();
            TaxInformationRepository taxRepo = new TaxInformationRepository();

            var productInfo = prodRepo.GetProducts().Where(x => x.ProductType.ToLower() == order.ProductType.ToLower()).First();
            var taxInfo = taxRepo.GetRates().Where(x => x.StateShort.ToLower() == order.State.ToLower()).First();
            order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
            order.LaborCostPerSquareFoot = productInfo.LaborCostPerSquareFoot;
            order.TaxRate = taxInfo.Rate;

            Console.WriteLine("****************************************");
            Console.WriteLine($"Order Number: {order.OrderNumber} | {order.Date}");
            Console.WriteLine($"Name: {order.CostumerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine("****************************************");

        }

        public static void DisplayProductInfo()
        {
            ProductInformationRepository repo = new ProductInformationRepository();
            var products = repo.GetProducts();
            Console.WriteLine("{0, -20}{1, -20}{2, -20}", "Product type", "Cost/sq ft", "Labor cost/sq ft");
            foreach (var product in products)
            {
                Console.WriteLine("{0, -20}{1, -20}{2, -20}", product.ProductType, product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
            }
        }

        public static void DisplayStates()
        {
            TaxInformationRepository repo = new TaxInformationRepository();
            var rates = repo.GetRates();
            foreach(var state in rates)
            {
                Console.WriteLine($"{state.State} ({state.StateShort})");
            }
        }
    }
}