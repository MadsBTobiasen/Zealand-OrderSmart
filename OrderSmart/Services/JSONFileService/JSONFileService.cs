using Microsoft.AspNetCore.Hosting;
using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

/*
* 
* Af Mads
*
*/

namespace OrderSmart.Services.JSONService
{
    public class JSONFileService
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
            JSONOrderPath = Path.Combine(JSONBasePath, "Orders");

            Orders = ReadOrders().ToList();
            Products = ReadProducts().ToList();

            foreach(Order o in Orders)
            {
                Console.WriteLine(o);
            }
            
        }

        #region Orders Handling
        /// <summary>
        /// Method that takes an Order Object and writes it to a JSOn file.
        /// </summary>
        /// <param name="objects"></param>
        public void SaveOrderJSON(Order order)
        {

            List<object> objects = new List<object>()
            {
                order
            };

            string path = GenerateOrderJSONPath(JSONOrderPath, order);

            using (var jsonFileWriter = File.Create(path))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<object[]>(jsonWriter, objects.ToArray());
            }

        }

        /// <summary>
        /// Method that generates the path for the given order.
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="order"></param>
        /// <returns>Path to save to.</returns>
        private string GenerateOrderJSONPath(string basePath, Order order)
        {
            return Path.Combine(basePath, "Order_" + order.ID + ".json");
        }

        /// <summary>
        /// Method that reads Orders from the JSON file, defined in the path-properties above,
        /// and returns the read data, to be parsed into the list.
        /// </summary>
        /// <returns>Returns a list.</returns>
        private IEnumerable<Order> ReadOrders()
        {

            List<Order> orders = new List<Order>();
            string[] files = Directory.GetFiles(JSONOrderPath);

            foreach(string file in files)
            {
               
                using (var jsonFileReader = File.OpenText(Path.Combine(JSONOrderPath, file)))
                {
                    orders.AddRange(JsonSerializer.Deserialize<Order[]>(jsonFileReader.ReadToEnd()));
                }

            }

            return orders;

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
