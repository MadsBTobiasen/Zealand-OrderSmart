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

        #region
        private static int IDCounter { get; set; }
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
            
            ID = IDCounter;
            OrderStatus = orderStatus;
            Products = products;

            IDCounter++;

        }

        public Order()
        {

            ID = IDCounter;
            IDCounter++;

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
