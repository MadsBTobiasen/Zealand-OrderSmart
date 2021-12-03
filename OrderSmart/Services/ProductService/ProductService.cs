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

            foreach (Product p in Products) Console.WriteLine(p);

        }

        public List<Product> GetProducts()
        {
            return Products;
        }

    }
}
