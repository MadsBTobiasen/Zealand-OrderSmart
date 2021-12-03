using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Services.JSONService
{
    interface IJSONFileService
    {

        public List<Order> GetOrders();
        public List<Product> GetProducts();

    }
}
