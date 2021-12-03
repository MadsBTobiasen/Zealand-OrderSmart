using OrderSmart.Models;
using OrderSmart.Services.JSONService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<Product> GetAllProducts()
        {
            return Sort(Products);
        }

        /// <summary>
        /// ?
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
        /// ?
        /// </summary>
        /// <param name="sName">Search string the name.</param>
        /// <param name="sMinPrice">Search double for the min price.</param>
        /// <param name="sMaxPrice">Search double for the max price.</param>
        /// <returns>List of productst that matches the search params.</returns>
        public List<Product> GetProductsBySearch(string sName, double sMinPrice, double sMaxPrice)
        {
            
            List<Product> sortedProducts = new List<Product>();

            foreach(Product product in Products)
            {
                if(product.Name.Contains(sName) && product.Price >= sMinPrice && (product.Price <= sMaxPrice || sMaxPrice == 0.00))
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
        private List<Product> Sort(List<Product> products)
        {
            
            Product[] temp = products.ToArray();

            Array.Sort(temp, delegate (Product p1, Product p2) {
                return p1.Name.CompareTo(p2.Name);
            });

            return temp.ToList();

        }
        /// <summary>
        /// ?
        /// </summary>
        /// <param name="productId">Id of the product to find.</param>
        /// <param name="amount">Amount to add to order, and amount to decrease from stock.</param>
        /// <returns>The product object, to be added to an order.</returns>
        public Product UpdateStock(int productId, int amount)
        {

            foreach (Product product in Products)
            {

                if (product.ID == productId)
                {

                    product.Amount -= amount;
                    return new Product(productId, product.Name, amount, product.Price);

                }
            }

            return null;

        }

        #endregion

    }
}
