using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderSmart.Models;
using OrderSmart.Services.OrderService;
using System.Collections.Generic;

/*
*
* Af Martin
*
*/

namespace OrderSmart.Pages.CustomerOrderScreen
{
    public class CustomerOrderScreenModel : PageModel
    {
        private OrderService _orderService;

        public List<Order> Orders { get; set; }

        public CustomerOrderScreenModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Gets all orders from the list Orders
        /// </summary>
        public void OnGet()
        {
            Orders = _orderService.GetAllOrders();
        }

    }
}