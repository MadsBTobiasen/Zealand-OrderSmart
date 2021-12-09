using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderSmart.Services.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderSmart.Models;

/*
*
* Af Rasmus
* Service implementation & Refactoring af Mads
*
*/

namespace OrderSmart.Pages.Orders
{
    public class OrderDetailsModel : PageModel
    {

        public OrderService _orderService { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
        public int ID { get; set; }
        public Order SelectedOrder { get; set; }
        [BindProperty] public Order.Status SelectedStatus { get; set; }
        public List<SelectListItem> OrderStatusItems { get; set; }

        #region Constructor
        public OrderDetailsModel(OrderService orderService)
        {

            _orderService = orderService;
            
            OrderStatusItems = new List<SelectListItem>();
            OrderStatusItems = 
                Enum.GetValues(typeof(Order.Status)).Cast<Order.Status>()
                    .Select(e => new SelectListItem(e.GetDisplayName(), e.ToString())).ToList();

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns the page.
        /// </summary>
        public IActionResult OnGet(int id)
        {

            ID = id;
            SelectedOrder = _orderService.GetOrderByID(ID);

            if (SelectedOrder is null)
            {
                Errors.Add($"The order {ID} you selected could not be found");
                return Page();
            }

            return Page();

        }

        /// <summary>
        /// Method that selects an order, based on the parsed ID. And allows the user to chaange the orders status.
        /// </summary>
        public IActionResult OnPost(int id)
        {

            ID = id;
            SelectedOrder = _orderService.GetOrderByID(ID);

            Console.WriteLine(SelectedOrder);
            Console.WriteLine(ID);

            if (SelectedOrder is null)
            {
                Errors.Add($"The order {ID} you selected could not be found");
                return Page();
            }

            _orderService.UpdateOrder(SelectedStatus, SelectedOrder);

            Console.WriteLine(SelectedOrder);
            Console.WriteLine(ID);

            return RedirectToPage("/Packing/Packing");
        }
        #endregion

    }
}
