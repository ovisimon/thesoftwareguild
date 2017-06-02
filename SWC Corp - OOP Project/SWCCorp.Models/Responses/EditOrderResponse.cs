using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Responses
{
    public class EditOrderResponse : Response
    {
        public EditOrderResponse()
        {
            Order = new Order();
        }
        public Order Order { get; set; }
    }
}
