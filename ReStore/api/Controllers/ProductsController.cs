using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] // api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
                return NotFound();

            return products;
        }
    }
}
