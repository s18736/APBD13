using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD13.Models
{
    public class OrderItemRequest
    {
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int ConfectioneryId { get; set; }
    }
}
