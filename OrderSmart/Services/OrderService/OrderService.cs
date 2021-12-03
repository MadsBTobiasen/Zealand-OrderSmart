using OrderSmart.Models;
using OrderSmart.Services.JSONService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Services.OrderService
{
    public class OrderService : IOrderService
    {

        private JSONFileService _jsonFileService { get; set; }
        private List<Order> Orders { get; set; }

        public OrderService(JSONFileService jsonFileService)
        {

            _jsonFileService = jsonFileService;
            Orders = _jsonFileService.GetOrders();

        }

        /// <summary>
        /// Method that adds an Order to the list of orders.
        /// </summary>
        /// <param name="order">Order to be added.</param>
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return Orders;
        }

        /// <summary>
        /// Method that updates the status of the order.
        /// </summary>
        /// <param name="status">The new status of the order.</param>
        /// <param name="order">The order to update.</param>
        public void UpdateOrder(Order.Status status, Order order)
        {
            order.OrderStatus = status;
        }

        /// <summary>
        /// Method that deletes an order from the list.
        /// </summary>
        /// <param name="order">Order to be removed.</param>
        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
        }

        /// <summary>
        /// Method that gets all orders given by the status.
        /// </summary>
        /// <param name="status">Status to search for.</param>
        /// <returns>Orders retrieved.</returns>
        public IEnumerable<Order> GetOrdersByStatus(Order.Status status)
        {

            List<Order> orders = new List<Order>();

            foreach(Order o in Orders)
            {
                if (o.OrderStatus == status) orders.Add(o);
            }

            return orders;

        }

    }
}
