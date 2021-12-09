using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderSmart.Models;
using OrderSmart.Services.OrderService;
using OrderSmart.Services.ProductService;
using System.ComponentModel.DataAnnotations;
/*
 * Af Falke & Mads
*/
namespace OrderSmart.Pages.OrderPlace
{
    public class OrderPlace : PageModel
    {
        public Order Order { get; set; }
        public static List<Product> Stock { get; set; }
        public OrderService _orderService { get; set; }
        public ProductService _productService { get; set; }
        public static List<Product> Cart { get; set; }
        public static double TotalPriceCart { get; set; }
        [BindProperty] public string SearchName { get; set; }
        [BindProperty] public string SearchMinPrice { get; set; }
        [BindProperty] public string SearchMaxPrice { get; set; }


        /// <summary>
        /// Constructor for the class. Note: if statement to the initialization of Stock is necessary to stop resetting search filtered products when you add to cart
        /// </summary>
        #region Constructor

        #region Mads
        public OrderPlace(OrderService orderService, ProductService productService)
        {

            _orderService = orderService;
            _productService = productService;

            if(Stock == null) Stock = _productService.GetAllProducts(); //edited by Falke

            foreach (Order o in _orderService.GetAllOrders())
            {
                Console.WriteLine(o);
            }

        }
        #endregion

        #endregion

        #region Methods

        #region Mads
        /// <summary>
        /// OnGet() gets called when the user loads the page.
        /// </summary>
        public IActionResult OnGet()
        {

            return Page();

        }
        #endregion

        #region Falke
        /// <summary>
        /// Creates Cart if none exist. Uses parameters to add a refrence-less product to cart
        /// or updates the amount property of the appropriate product in the cart if a product with a matching
        /// ID already exists. If amount property of product in cart exceeds amount in stock it sets amount to
        /// be equal to the matching products amount in stock
        /// also recalculates total price of cart
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public IActionResult OnPostToCart(int id, string name, int amount, double price)
        {
            if (Cart == null)
            {
                Cart = new List<Product>();
            }
            if (Cart.Exists(p => p.ID == id))
            {
                foreach (Product p in Cart)
                {
                    if (id == p.ID)
                    {
                        p.Amount += amount;
                        foreach(Product product in Stock)
                        {
                            if (p.ID == product.ID && p.Amount > product.Amount)
                            {
                                p.Amount = product.Amount;
                            }
                        }
                    }
                }
            }
            else
            {
                if (amount > 0)
                {
                    Cart.Add(new Product(id, name, amount, price));
                }
            }

            TotalPriceCart = 0;
            foreach (Product p in Cart)
            {
                TotalPriceCart += (p.Price * p.Amount);
            }

            return Page();
        }
        /// <summary>
        /// Gets called when you press "fjern" by a product. matches ID to product in cart and decreases the amount property by the chosen amount
        /// (product is removed from list if Amount reaches 0). Also decreases total price of cart by the appropriate amount.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public IActionResult OnPostRemoveFromCart(int id, int amount)
        {
            foreach(Product p in Cart.ToList())
            {
                if (id == p.ID)
                {
                    p.Amount -= amount;
                    TotalPriceCart -= (p.Price * amount);
                }
                if (p.Amount <= 0) Cart.Remove(p);
            }
            return Page();
        }

        /// <summary>
        /// OnPostSearch() gets called when the user, hits the "search" button, uses a service to return specific products matching search criteria.
        /// Note: min- and maxPrice originate from strings in order to be able to see the placeholder text in the searchbar.
        /// </summary>
        public IActionResult OnPostSearch()
        {
            Stock = _productService.GetProductsBySearch(SearchName, Convert.ToDouble(SearchMinPrice), Convert.ToDouble(SearchMaxPrice));
            return Page();
        }
        #endregion

        #region Falke & Mads
        /// <summary>
        /// OnPostBuy() gets called when the button "køb" is pressed, uses cart to create new order object and adds it to list of orders.
        /// Also updates the stock to represent the sale of products and clears the cart and total price of cart so they're ready and reset for the next order.
        /// </summary>
        public IActionResult OnPostBuy()
        {
            //Mads
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if (Cart != null)
            {
                if (Cart.Count > 0)
                {
                    Order = new Order(Order.Status.Recieved, Cart.ToList()); //Forslag: Ændre order parameter så den kun tager en liste af produkter og status bliver sat i body til recieved
                    Order.GetID(_orderService);
                    _orderService.AddOrder(Order);
                }
                //Falke
                _productService.UpdateStock(Cart);

                Cart.Clear();
                TotalPriceCart = 0;

                return Redirect("/Packing/Packing");
            }

            return Page();

        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #endregion

    }
}
