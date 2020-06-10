using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD13.Entities
{
    public class Confectionery
    {
        public int IdConfecti { get; set; }
        public string Name { get; set; }
        public double PricePerite { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ConfectioneryOrder> ConfectioneryOrders { get; set; }
    }
}
