using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderSmart.Models;
using OrderSmart.Services.OrderService;

namespace OrderSmart.Pages.CustomerOrderScreen
{
    public class CustomerOrderScreenModel : PageModel
    {

        private OrderService _orderService;

        public List<Order> Orders { get; set; }

        [BindProperty] public int ID { get; set; }

        [BindProperty] public Order.Status OrderStatus { get; set; }

        public CustomerOrderScreenModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            Orders = _orderService.GetAllOrders();
        }

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }



        //   // catalog.AddPizza(Pizza);
        //   // return RedirectToPage("GetAllPizzas");
        //}

    }
}