using SWCCorp.BLL;
using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderToRemove = new Order();

            Console.Clear();
            Console.WriteLine("Remove order");
            Console.WriteLine("**********");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the date of the order to remove: (YYYY/MM/DD)");
                    //here I have to look up the file with that date
                    orderToRemove.Date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid date. Please try again!");
                }
            }
            Console.WriteLine("Enter the number of the order: ");
            int orderNumber = int.Parse(Console.ReadLine());
            string path = manager.FileName(orderToRemove.Date);

            orderToRemove = manager.DisplayOrder(path, orderNumber).Order;
            Console.WriteLine("These are the details of the order that you want to remove: ");
            
            ConsoleIO.DisplayOrderDetails(orderToRemove);

            Console.WriteLine("Are you sure you want to remove it? (Y/N)");
            string input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                //remove the order from the repository
                manager.RemoveOrder(orderNumber, path);
                Console.WriteLine("The order has been removed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if (input == "N" || input == "n")
            {
                Console.WriteLine("Action cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
    }
}
