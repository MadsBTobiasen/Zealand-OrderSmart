using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderSmart.Services.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderSmart.Models;
using Microsoft.AspNetCore.Mvc;

/*
*
* Af Rasmus
* Service implementation af Mads
*
*/
namespace OrderSmart.Pages.Orders
{  
    public class PackingModel : PageModel
    {
        public OrderService _orderService { get; set; }

        #region Constructor
        public PackingModel(OrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion

        #region Methods
        public IActionResult OnGet()
        {
            return Page();
        }

        public List<Order> GetOrdersByStatus(Order.Status status)
        {
            return _orderService.GetOrdersByStatus(status).ToList();
        }
        #endregion

    }
}
