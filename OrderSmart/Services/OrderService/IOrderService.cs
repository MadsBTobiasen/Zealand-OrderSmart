using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
* 
* Af Mads
*
*/

namespace OrderSmart.Services.OrderService
{
    interface IOrderService
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrderByID(int id);
        void UpdateOrder(Order.Status status, Order order);
        void DeleteOrder(Order order);
        int GenerateID();

    }
}
