using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD13.Models
{
    public class OrderResponse
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public ICollection<OrderItemResponse> Items { get; set; }
    }
}
