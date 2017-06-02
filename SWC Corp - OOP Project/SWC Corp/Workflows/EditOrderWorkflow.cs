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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderToEdit = new Order();

            Console.Clear();
            Console.WriteLine("Edit order");
            Console.WriteLine("**********");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the date of the order to display: (MM/DD/YYYY)");
                    orderToEdit.Date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid date. Please try again!");
                }
            }

            string path = manager.FileName(orderToEdit.Date);

            if (!manager.DoesFileExist(path))
            {
                Console.WriteLine("There are no orders for that date!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the number of the order: ");
            int orderNumber = int.Parse(Console.ReadLine());

            
            orderToEdit = manager.DisplayOrder(path, orderNumber).Order;

            Console.Clear();
            Console.WriteLine("These are the details of the order that you want to edit: ");
            ConsoleIO.DisplayOrderDetails(orderToEdit);
            Console.WriteLine();

            Console.WriteLine($"Enter a new name, or press Enter to skip this step ({orderToEdit.CostumerName}): ");
            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                orderToEdit.CostumerName = input;
            }

            Console.WriteLine($"Enter a new state, or press Enter to skip this step ({orderToEdit.State}): ");
            input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                orderToEdit.State = input;
            }

            Console.WriteLine($"Enter a new Product Type, or press Enter to skip this step ({orderToEdit.ProductType}): ");
            input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                orderToEdit.ProductType = input;
            }
            
            while (true)
            {
                try
                {
                    Console.WriteLine($"Enter a new area, or press Enter to skip this step ({orderToEdit.Area}): ");
                    input = Console.ReadLine();
                    if (!String.IsNullOrEmpty(input))
                    {
                        orderToEdit.Area = decimal.Parse(input);
                    }
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid area. You must enter a decimal!");
                }
            }

            Console.Clear();
            Console.WriteLine("This are the new details on the order:");
            ConsoleIO.DisplayOrderDetails(orderToEdit);
            Console.WriteLine();
            Console.WriteLine("Do you want to save the new details? (Y/N)");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")
            {
                //save the order in the repository
                manager.EditOrder(orderToEdit, orderNumber, path);
                Console.WriteLine("The details have been updated!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if(input == "N" || input == "n")
            {
                Console.WriteLine("The new details have been discarded!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            else
            {
                Console.WriteLine("The new details have been discarded!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
    }
}
