using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OrderSmart.Models;
using OrderSmart.Services.OrderService;
using OrderSmart.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ProductService productService, OrderService orderService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
