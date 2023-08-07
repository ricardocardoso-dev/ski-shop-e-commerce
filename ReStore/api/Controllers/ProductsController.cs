using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] // api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Products.FindAsync(id);
        }
        
    }
}