using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Model;
using StoreApi.Repo;
using System.Collections;

namespace StoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products;
       public ProductsController() {
            products = DbContext.Products();
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Products() => products;

        [HttpGet("{id}")]
        public async Task<Product> Products(int id) {
            
            return products.Where(_ => _.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IEnumerable<Product>> Products(Product p ) {
            products.Add(p);
            return products;
        }

    }
}
