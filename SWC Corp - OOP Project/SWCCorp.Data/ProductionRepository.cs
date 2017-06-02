using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.Models;
using System.IO;

namespace SWCCorp.Data
{
    public class ProductionRepository : IOrderRepository
    {
        public Order AddOrder(Order order, string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string line = CreateCsvForOrder(order);

                    sw.WriteLine(line);
                }

                return order;
            }

            else
            {
                File.Create(path).Close();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    order.OrderNumber = 1;
                    string line = CreateCsvForOrder(order);
                    sw.WriteLine("OrderNumber|CostumerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                    sw.WriteLine(line);
                }

                return order;
            }
        }

        public List<Order> GetOrders(string path)
        {
            List<Order> orders = new List<Order>();

            if (File.Exists(path))
            {
                var reader = File.ReadAllLines(path);

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('|');

                    var order = new Order();

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CostumerName = columns[1];
                    order.State = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                    orders.Add(order);
                }
            }
            
            return orders;
        }

        public Order LoadOrder(string path, int orderNumber)
        {
            List<Order> orders = GetOrders(path);
            
            return orders.FirstOrDefault(x => x.OrderNumber == orderNumber);
        }

        public void SaveOrder(Order orderToSave)
        {
            string path = "";
            var orders = GetOrders(path);

            var currentOrder = orders.First(x => x.OrderNumber == orderToSave.OrderNumber);
            currentOrder.CostumerName = orderToSave.CostumerName;
            currentOrder.State = orderToSave.State;
            // currentOrder.TaxRate = orderToSave.TaxRate;
            currentOrder.ProductType = orderToSave.ProductType;
            currentOrder.Area = orderToSave.Area;
            //currentOrder.CostPerSquareFoot = orderToSave.CostPerSquareFoot;
            //currentOrder.LaborCostPerSquareFoot = orderToSave.LaborCostPerSquareFoot;

            //OverwriteFile(orders);
        }

        //private void OverwriteFile(List<Order> orders)
        //{
        //    try
        //    {
        //        File.Delete(filePath);

        //        using (var writer = File.CreateText(filePath))
        //        {
        //            writer.WriteLine("OrderNumber|CostumerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");

        //            foreach(var order in orders)
        //            {
        //                writer.WriteLine($"{order.OrderNumber}|{order.CostumerName}|{order.State}|{order.TaxRate}|{order.ProductType}|{order.Area}|{order.CostPerSquareFoot}|{order.LaborCostPerSquareFoot}|{order.MaterialCost}|{order.LaborCost}|{order.Tax}|{order.Total}");
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        private string CreateCsvForOrder(Order order)
        {
            { 
               return string.Format($"{order.OrderNumber.ToString()}|{order.CostumerName}|{order.State}|{order.TaxRate.ToString()}|{order.ProductType}|{order.Area.ToString()}|{order.CostPerSquareFoot.ToString()}|{order.LaborCostPerSquareFoot.ToString()}|{order.MaterialCost.ToString()}|{order.LaborCost.ToString()}|{order.Tax.ToString()}|{order.Total.ToString()}");
            }
        }

        public Order EditOrder(Order order, int orderNumber, string path)
        {
            var orders = GetOrders(path);

            var orderToEdit = orders.First(x => x.OrderNumber == order.OrderNumber);
            
            orderToEdit = order;

            CreateOrderFile(orders, path);

            return order;
        }

        public void RemoveOrder(Order order, int orderNumber, string path)
        {
            var orders = GetOrders(path);

            orders.RemoveAt(orderNumber);

            CreateOrderFile(orders, path);
        }

        private void CreateOrderFile(List<Order> orders, string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("OrderNumber|CostumerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                foreach(var order in orders)
                {
                    sw.WriteLine(CreateCsvForOrder(order));
                }
            }
        }

        public string FileName(DateTime date)
        {
            return $".\\Repositories\\Orders_{date.Month}{date.Day}{date.Year}.txt";
        }

        public int GetCurrentIndex(string path)
        {
            int currentIndex = File.ReadAllLines(path).Length;
            return currentIndex;
        }
    }
}
