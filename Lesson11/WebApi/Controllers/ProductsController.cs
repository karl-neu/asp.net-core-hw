using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public ProductsController(CatalogDbContext context)
        {
            _context = context;
        }

        //https://localhost:5001/Products/GetProducts

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        //https://localhost:5001/Products/GetProduct?id=1           //FromQuery

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Product>> GetProduct([FromQuery] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        //https://localhost:5001/Products/PutProduct

        /* PUT /Products/PutProduct HTTP/1.1
             Host: localhost:5001
             id: 1
             Content-Type: application/json
             Content-Length: 112

             {
                 "id": 1,
                 "title": "Tomato223",
                 "price": 2.7,
                 "warehouseId": 1,
                 "warehouse": null
               }*/
        [HttpPut]
        [Route("[action]")]                         //id - FromHeader, product - FromBody
        public async Task<IActionResult> PutProduct([FromHeader] int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //https://localhost:5001/Products/PostProduct

        /*POST /Products/PostProduct HTTP/1.1
            Host: localhost:5001
            Content-Type: application/json
            Content-Length: 88
            
            {
              "title": "Tomato24",
              "price": 7.13,
              "warehouseId": 1,
              "warehouse": null
            }*/

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        //https://localhost:5001/Products/DeleteProduct/3

        [HttpDelete]
        [Route("[action]/{id}")]                                    //FromRoute
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}