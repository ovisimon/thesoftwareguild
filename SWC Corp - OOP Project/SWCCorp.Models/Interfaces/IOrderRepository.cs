using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(string path, int OrderNumber);
        void SaveOrder(Order order);
        Order AddOrder(Order order, string path);
        Order EditOrder(Order order, int orderNumber, string path);
        void RemoveOrder(Order order, int orderNumber, string path);

    }
}
