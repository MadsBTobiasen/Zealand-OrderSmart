using OrderSmart.Models;
using OrderSmart.Services.JSONService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
* 
* Af Mads
*
*/

namespace OrderSmart.Services.ProductService
{
    public class ProductService : IProductService
    {

        private JSONFileService _jsonFileService { get; set; }
        private List<Product> Products { get; set; }

        public ProductService(JSONFileService jsonFileService)
        {
            
            _jsonFileService = jsonFileService;
            Products = _jsonFileService.GetProducts();

            Console.WriteLine("PRODUCT SERVICE CONSTRUCTOR");

        }

        #region Methods
        /// <summary>
        /// Method that returns the list of products.
        /// </summary>
        /// <returns>List of products.</returns>
        // Mads
        public List<Product> GetAllProducts()
        {
            return Sort(Products);
        }

        /// <summary>
        /// Useless. Was accidentally made for products instead of Order which is where this type of service would be needed
        /// </summary>
        /// <param name="productId">Id of the product to find.</param>
        /// <returns>Product that matches the id. Or null if none found.</returns>
        public Product GetProductByID(int productId)
        {

            foreach(Product product in Products)
            {
                if (product.ID == productId) return product;
            }

            return null;

        }

        /// <summary>
        /// Takes three arguments and picks out products that contains a string in its name and is within two price points.
        /// if string is null or either double is 0 anything goes for that parameter.
        /// </summary>
        /// <param name="sName">Search string the name.</param>
        /// <param name="sMinPrice">Search double for the min price.</param>
        /// <param name="sMaxPrice">Search double for the max price.</param>
        /// <returns>List of productst that matches the search params.</returns>
        // Mads
        public List<Product> GetProductsBySearch(string sName, double sMinPrice, double sMaxPrice)
        {
            if (sName == null)
            {
                sName = ""; //addition by Falke
            }
            List<Product> sortedProducts = new List<Product>();

            foreach (Product product in Products)
            {
                if (product.Name.ToLower().Contains(sName.ToLower()) && product.Price >= sMinPrice && (product.Price <= sMaxPrice || sMaxPrice == 0.00))
                {
                    sortedProducts.Add(product);
                }
            }


            return Sort(sortedProducts);
        }

        /// <summary>
        /// Method that sorts the list given in the parameter by the name.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        // Mads
        private List<Product> Sort(List<Product> products)
        {
            
            Product[] temp = products.ToArray();

            Array.Sort(temp, delegate (Product p1, Product p2) {
                return p1.Name.CompareTo(p2.Name);
            });

            return temp.ToList();

        }
        /// <summary>
        /// Method that goes through a list of products(Cart) and matches each product to another list of products(representing stock products).
        /// When a match is found, the Amount property of the product in Products, get updated accordingly.
        /// </summary>
        /// <param name="product">Product object to be added to the cart.</param>
        /// <param name="amount">Amount to add to order, and amount to decrease from stock.</param>
        /// <returns>The product object, to be added to an order.</returns>
        // Falke
        public void UpdateStock(List<Product> toUpdate)
        {
            foreach(Product p in toUpdate)
            {
                foreach (Product stock in Products)
                {

                    if (p.ID == stock.ID)
                    {

                        Console.WriteLine(stock);
                        stock.Amount -= p.Amount;
                        Console.WriteLine(stock);

                    }

                }
            }
        }

        #endregion

    }
}
