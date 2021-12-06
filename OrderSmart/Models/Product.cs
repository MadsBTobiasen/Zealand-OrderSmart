using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Models
{
    public class Product
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
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
