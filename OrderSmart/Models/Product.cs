using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Models
{
    public class Product
    {

        #region Properties
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public double Price { get; private set; }
        #endregion

        #region Constructor
        public Product(int id, string name, int amount, double price)
        {
            ID = id;
            Name = name;
            Amount = amount;
            Price = price;
        }

        public Product()
        {

        }
        #endregion

        public override string ToString()
        {
            return $"Single: {Name} {Amount} {Price}";
        }

    }
}
