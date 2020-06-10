using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD13.Models;

namespace APBD13.Services
{
    public interface IConfectioneryDbService
    {
        ICollection<OrderResponse> GetOrders(string name);
        ICollection<OrderResponse> GetOrders();
        int AddOrder(AddOrderRequest request, int id);
    }
}
