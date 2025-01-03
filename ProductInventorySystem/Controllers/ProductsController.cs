using Microsoft.AspNetCore.Mvc;
using ProductInventorySystem.Data;
using ProductInventorySystem.Models;
using static ProductInventorySystem.DbContext;

namespace ProductInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product data is null.");

            product.Id = Guid.NewGuid();
            product.CreatedDate = DateTimeOffset.UtcNow;
            product.UpdatedDate = DateTimeOffset.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
        
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}

