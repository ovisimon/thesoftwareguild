using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Models;

namespace TipCalculator.BLL
{
    public class OrderManager
    {
        public Order CalculateTotal(Order order)
        {
            order.Total = order.TotalWithoutTip + order.TotalWithoutTip * (order.Tip/100);
            return order;
        }
    }
}
