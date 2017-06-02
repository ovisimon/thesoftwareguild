using SWCCorp.BLL;
using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();
            DateTime orderDate;

            Console.Clear();
            Console.WriteLine("Display order: ");
            Console.WriteLine("**************");
            Console.WriteLine();
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the date of the order to display: (MM/DD/YYYY)");
                    //here I have to look up the file with that date
                    orderDate = DateTime.Parse(Console.ReadLine());
                    
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid date. Please try again!");
                }
            }

            string path = manager.FileName(orderDate);

            if (!File.Exists(path))
            {
                Console.WriteLine("There are no orders for that date!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            int orderNumber;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the number of the order: ");
                    orderNumber = int.Parse(Console.ReadLine());
                    if (File.ReadAllLines(path).Length <= orderNumber)
                    {
                        Console.WriteLine("There is no order with that number!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    newOrder = manager.DisplayOrder(path, orderNumber).Order;
                    newOrder.Date = orderDate;
                    break;
                }

                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a number!");
                }
            }

            
            

            Console.Clear();
            ConsoleIO.DisplayOrderDetails(newOrder);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
    }
}
