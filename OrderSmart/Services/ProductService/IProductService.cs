using OrderSmart.Models;
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
    public interface IProductService
    {

        public List<Product> GetAllProducts();
        public Product GetProductByID(int productId);
        public List<Product> GetProductsBySearch(string sName, double sMinPrice, double sMaxPrice); //Edited by Falke
        public void UpdateStock(List<Product> toUpdate);

    }
}
