using OrderSmart.Services.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
* 
* Af Mads
*
*/

namespace OrderSmart.Models
{
    public class Order
    {

        #region Enum
        public enum Status
        {
            Recieved = 0,
            InProgress = 1,
            Done = 2,
            Delivered = 3
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public Status OrderStatus { get; set; }
        public double Price { get { return CalculatePrice(); } }
        public List<Product> Products { get; set; }
        #endregion
        
        #region Constructors
        public Order(Status orderStatus, List<Product> products) //Forslag: Ændre order parameter så den kun tager en liste af produkter og status bliver sat i body til recieved
        {

            ID = 0;
            OrderStatus = orderStatus;
            Products = products;

        }

        public Order() { }
        #endregion

        #region Methods
        /// <summary>
        /// Method that itterates through all the products in Order, and returns the total price.
        /// </summary>
        /// <returns></returns>
        private double CalculatePrice()
        {

            double price = 0.00;

            foreach (Product p in Products)
            {
                price += (p.Price * p.Amount);
            }

            return price;

        }

        /// <summary>
        /// Method that gets a unique ID for the order.
        /// </summary>
        /// <param name="orderService"></param>
        public void GetID(OrderService orderService)
        {
            ID = orderService.GenerateID();  
        }

        public override string ToString()
        {
            return $"Order: {ID} {OrderStatus} {Price} {Products.Count}";
        }
        #endregion

    }
}
