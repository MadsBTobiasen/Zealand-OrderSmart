using Microsoft.AspNetCore.Hosting;
using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderSmart.Services.JSONService
{
    public class JSONFileService : IJSONFileService
    {

        #region Properties
        public IWebHostEnvironment WebHostEnvironment { get;}
        private static List<Order> Orders { get; set; }
        private static List<Product> Products { get; set; }
        private string JSONProductPath { get; set; }
        private string JSONOrderPath { get; set; }
        private string JSONBasePath { get; set; }
        #endregion

        public JSONFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;

            JSONBasePath = Path.Combine(webHostEnvironment.WebRootPath, "Data");
            JSONProductPath = Path.Combine(JSONBasePath, "Products.json");
            JSONOrderPath = Path.Combine(JSONBasePath, "Orders.json");

            Orders = ReadOrders().ToList();
            Products = ReadProducts().ToList();
        }

        #region Orders Handling
        /// <summary>
        /// Method that reads Orders from the JSON file, defined in the path-properties above,
        /// and returns the read data, to be parsed into the list.
        /// </summary>
        /// <returns>Returns a list.</returns>
        private IEnumerable<Order> ReadOrders()
        {

            using (var jsonFileReader = File.OpenText(JSONProductPath))
            {
                return JsonSerializer.Deserialize<Order[]>(jsonFileReader.ReadToEnd());
            }

        }

        /// <summary>
        /// Method that returns a list of all the orders.
        /// </summary>
        /// <returns>List of Orders</returns>
        public List<Order> GetOrders()
        {
            return Orders;
        }
        #endregion

        #region Products Handling
        /// <summary>
        /// Method that reads Products from the JSON file, defined in the path-properties above,
        /// and returns the read data, to be parsed into the list.
        /// </summary>
        /// <returns>Returns a list.</returns>
        private IEnumerable<Product> ReadProducts()
        {

            using (var jsonFileReader = File.OpenText(JSONProductPath))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd());
            }

        }

        /// <summary>
        /// Method that returns a list of all the products.
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> GetProducts()
        {
            return Products;
        }
        #endregion

    }
}
