using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.Models;

namespace SWCCorp.Data
{
    public class TestRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        public TestRepository()
        {
            _orders.Add(new Order()
            {
                OrderNumber = 12345,
                CostumerName = "Ovi Simon",
                State = "MI",
                Area = 200M,
                Date = DateTime.Parse("12/12/2019")
            });

            _orders.Add(new Order()
            {
                OrderNumber = 23456,
                CostumerName = "John Smith",
                State = "PA",
                Area = 300M,
                Date = DateTime.Parse("12/12/2019")
            });

            _orders.Add(new Order()
            {
                OrderNumber = 34567,
                CostumerName = "Bob Smith",
                State = "OH",
                Area = 400M,
                Date = DateTime.Parse("12/12/2019")
            });

            _orders.Add(new Order()
            {
                OrderNumber = 45678,
                CostumerName = "Tom Smith",
                State = "IN",
                Area = 500M,
                Date = DateTime.Parse("12/12/2019")
            });
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public Order LoadOrder(string path, int orderNumber)
        {
            List<Order> orders = GetAllOrders();
            return orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        public Order AddOrder(Order order, string path)
        {
            Order toAdd = order;
            _orders.Add(toAdd);
            return toAdd;
        }

        public Order EditOrder(Order order, int orderNumber, string path)
        {
            Order _order = LoadOrder(path, orderNumber);
            _order.CostumerName = order.CostumerName;
            _order.State = order.State;
            _order.ProductType = order.ProductType;
            _order.Area = order.Area;

            return order;
        }

        public void RemoveOrder(Order order, int orderNumber, string path)
        {
            var removed = _orders.Where(x => x.OrderNumber == orderNumber).First();
            _orders.Remove(removed);
        }

        public void SaveOrder(Order order)
        {
            Order _order = order;
        }
    }
}
