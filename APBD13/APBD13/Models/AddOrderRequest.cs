using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD13.Models
{
    public class AddOrderRequest
    {
        public string Notes { get; set; }
        public ICollection<OrderItemRequest> RequestedItems { get; set; } 
    }
}
