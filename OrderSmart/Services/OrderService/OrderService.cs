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

    }
}
