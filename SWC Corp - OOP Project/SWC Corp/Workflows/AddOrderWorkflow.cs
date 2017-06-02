using SWCCorp.BLL;
using SWCCorp.Data;
using SWCCorp.Models;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            AddOrderResponse response = new AddOrderResponse();
            TaxInformationRepository taxRepo = new TaxInformationRepository();
            //delete tax repo, do it from the manager, add a method to get the states

            DateTime now = new DateTime();
            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine("***************************");

            while (true)
            {
                try
                {
                    Console.WriteLine("Order date: (MM/DD/YYYY)");
                    var dateString = Console.ReadLine();
                    response.Order.Date = DateTime.Parse(dateString);
                    break;
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid date. Please try again!");
                }
            }

            Console.WriteLine("Costumer Name: ");
            response.Order.CostumerName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Costumer home state: ");
                response.Order.State = Console.ReadLine();
                var state = response.Order.State;
                if (manager.GetStates().Any(x => x.StateShort == state))
                {
                    break;
                }
               
                else
                {
                    Console.Clear();
                    Console.WriteLine("Unfortunately we do not sale in {0}.", response.Order.State);
                    Console.WriteLine("These are the states in which we sell: ");
                    Console.WriteLine();
                    ConsoleIO.DisplayStates();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("These are the products that you can choose from:");
            Console.WriteLine();
            ConsoleIO.DisplayProductInfo();
            Console.WriteLine();
            Console.WriteLine("Choose a type: ");
            response.Order.ProductType = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Area: ");
                    response.Order.Area = decimal.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid area. You must enter a decimal!");
                }
            }

            Console.Clear();
            Console.WriteLine("This is your order: ");
            ConsoleIO.DisplayOrderDetails(response.Order);
            Console.WriteLine("Are you sure you want to add it? (Y/N)");
            string input = Console.ReadLine();

            if(input == "Y" || input == "y")
            {
                manager.AddOrder(response.Order, manager.FileName(response.Order.Date));
                Console.Clear();
                Console.WriteLine("This order has been added: ");
                ConsoleIO.DisplayOrderDetails(response.Order);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Your order has been discarded!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
    }
}
