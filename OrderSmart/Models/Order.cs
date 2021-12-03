using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Order(int id, Status orderStatus, List<Product> products)
        {
            ID = id;
            OrderStatus = orderStatus;
            Products = products;
        }

        public Order()
        {

        }
        #endregion

        #region Methods
        private double CalculatePrice()
        {

            double price = 0.00;

            foreach (Product p in Products)
            {
                price += p.Price;
            }

            return price;

        }

        public override string ToString()
        {
            return $"Order: {ID} {OrderStatus} {Price} {Products.Count}";
        }
        #endregion

    }
}
