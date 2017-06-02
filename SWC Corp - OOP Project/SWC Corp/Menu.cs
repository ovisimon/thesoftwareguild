using SWC_Corp.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("* Floring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an order");
                Console.WriteLine("* 3. Edit an order");
                Console.WriteLine("* 4. Remove an order");
                Console.WriteLine("* 5. Quit");
                Console.WriteLine("*");
                Console.WriteLine("********************************************************");

                Console.Write("\nEnter selection: ");


                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        DisplayOrdersWorkflow displayOrdersWorkflow = new DisplayOrdersWorkflow();
                        displayOrdersWorkflow.Execute();
                        break;

                    case "2":
                        AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                        addOrderWorkflow.Execute();
                        
                        break;

                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Execute();
                        break;

                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Execute();
                        break;

                    case "5":
                        return;

                    case "q":
                        return;

                    case "Q":
                        return;
                }
            }
        }
    }
}
