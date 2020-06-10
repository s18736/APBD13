using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD13.Entities
{
    public class ConfectioneryOrder
    {
        public int IdConfection { get; set; }
        public virtual Confectionery Confectionery { get; set; }
        public int IdOrder { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
