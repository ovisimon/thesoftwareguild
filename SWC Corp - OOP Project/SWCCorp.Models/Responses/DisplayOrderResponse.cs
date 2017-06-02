using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Responses
{
    public class DisplayOrderResponse : Response
    {
        public DisplayOrderResponse()
        {
            Order = new Order();
        }
        public Order Order { get; set; }
    }
}
