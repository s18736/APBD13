using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD13.Entities;
using APBD13.Models;

namespace APBD13.Services
{
    public class ConfectioneryDbService : IConfectioneryDbService
    {
        private ConfectioneryContext _context;

        public ConfectioneryDbService(ConfectioneryContext context)
        {
            _context = context;
        }

        //adding orders
        public int AddOrder(AddOrderRequest request, int id)
        {
            if (!isAddingRequestValid(request))
            {
                return -3;
            }
            if (!containsAllConfectionery(request.RequestedItems))
            {
                return -1;
            }
            if (!isCustomerValid(id))
            {
                return -2;
            }
            var order = addOrderToDb(request, id);
            addOrderItemsToDb(request, order);
            _context.SaveChanges();
            return 0;
        }

        private bool isAddingRequestValid(AddOrderRequest request)
        {
            return request.RequestedItems != null;
        }

        private Order addOrderToDb(AddOrderRequest request, int id)
        {
            var customer = _context.Customers.Where(c => c.IdClient == id).First();
            var employee = _context.Employees.First();
            var order = new Order()
            {
                Customer = customer,
                Notes = request.Notes,
                Employee = employee
            };
            _context.Orders.Add(order);
            return order;
        }

        private void addOrderItemsToDb(AddOrderRequest request, Order order)
        {
            foreach (var item in request.RequestedItems)
            {
                var confectionery = _context.Confectioneries.Where(c => c.IdConfecti == item.ConfectioneryId).First();
                var confOrder = new ConfectioneryOrder()
                {
                    Order = order,
                    Notes = item.Notes,
                    Quantity = item.Quantity,
                    Confectionery = confectionery
                };

            }
        }

        private bool isCustomerValid(int id)
        {
            return _context.Customers.Any(c => c.IdClient == id);
        }

        private bool containsAllConfectionery(ICollection<OrderItemRequest> items)
        {
            foreach (var item in items)
            {
                int id = item.ConfectioneryId;
                bool containsId = _context.Confectioneries.Any(c => c.IdConfecti == id);
                if (!containsId)
                {
                    return false;
                }
            }
            return true;
        }


        //getting orders
        public ICollection<OrderResponse> GetOrders(string name)
        {
            List<Order> orders = (from order in _context.Orders
                                  join customer in _context.Customers
                                  on order.IdCustomer equals customer.IdClient
                                  where customer.Name == name
                                  select order).ToList();

            return getOrderResponses(orders);
        }

        public ICollection<OrderResponse> GetOrders()
        {
            List<Order> orders = _context.Orders.ToList();
            return getOrderResponses(orders);
        }


        private ICollection<OrderResponse> getOrderResponses(List<Order> orders)
        {
            List<OrderResponse> response = new List<OrderResponse>();
            foreach (var order in orders)
            {
                var orderRes = buildOrderResponse(order);
                response.Add(orderRes);
            }
            return response;
        }

        private OrderResponse buildOrderResponse(Order order)
        {
            OrderResponse orderRes = new OrderResponse();
            orderRes.IdOrder = order.IdOrder;
            orderRes.DateAccepted = order.DateAccepted;
            orderRes.DateFinished = order.DateFinished;
            orderRes.Notes = order.Notes;
            List<ConfectioneryOrder> orderItems = _context.ConfectioneryOrders.Where(co => co.IdOrder == order.IdOrder).ToList();
            List<OrderItemResponse> orderItemsRes = new List<OrderItemResponse>();
            foreach (var orderItem in orderItems)
            {
                var orderItemRes = buildOrderItemResponse(orderItem);
                orderItemsRes.Add(orderItemRes);
            }
            orderRes.Items = orderItemsRes;
            return orderRes;
        }

        private OrderItemResponse buildOrderItemResponse(ConfectioneryOrder confOrder)
        {
            Confectionery confectionery = _context.Confectioneries.Where(c => c.IdConfecti == confOrder.IdConfection).First();
            OrderItemResponse response = new OrderItemResponse()
            {
                ConfectioneryName = confectionery.Name,
                Type = confectionery.Type,
                Quantity = confOrder.Quantity
            };
            return response;
        }


    }

}



