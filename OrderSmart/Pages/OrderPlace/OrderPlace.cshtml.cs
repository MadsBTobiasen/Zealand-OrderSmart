using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderSmart.Models;
using OrderSmart.Services.OrderService;
using OrderSmart.Services.ProductService;

namespace OrderSmart.Pages.OrderPlace
{
    public class OrderPlace : PageModel
    {

        public Order Order { get; set; }
        public List<Product> Stock { get; set; }
        [BindProperty] public List<Product> Cart { get; set; }
        public OrderService _orderService { get; set; }
        public ProductService _productService { get; set; }
        [BindProperty] public string SearchName { get; set; }
        [BindProperty] public double SearchMinPrice { get; set; }
        [BindProperty] public double SearchMaxPrice { get; set; }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        public OrderPlace(OrderService orderService, ProductService productService)
        {

            _orderService = orderService;
            _productService = productService;

            Stock = _productService.GetAllProducts();
             
            foreach(Order o in _orderService.GetAllOrders())
            {
                Console.WriteLine(o);
            }

        }

        #region Methods
        /// <summary>
        /// OnGet() gets called when the user loads the page.
        /// </summary>
        public IActionResult OnGet()
        {

            return Page();

        }

        /// <summary>
        /// OnPost() gets called when the order is confirmed, and should be added to the list of orders.
        /// </summary>
        public IActionResult OnPost()
        {

            if(!ModelState.IsValid)
            {
                return Page();
            }

            List<Product> productsToAdd = new List<Product>();
            
            foreach (Product p in Cart)
            {

                if(p.Amount > 0)
                {

                    Product productToAdd = _productService.UpdateStock(p, p.Amount);

                    if (productToAdd != null)
                    {
                        productsToAdd.Add(productToAdd);
                    }

                }

            }

            if (productsToAdd.Count > 0)
            {
                Order = new Order(Order.Status.Recieved, productsToAdd);
                _orderService.AddOrder(Order);
            }
            return Page();

        }

        /// <summary>
        /// OnPostSearch() gets called when the user, hits the "search" button, naad products to be sorted accordingly.
        /// </summary>
        public IActionResult OnPostSearch()
        {

            return Page();

        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}
