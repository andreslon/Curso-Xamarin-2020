using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cedesistemas.Api.Data;
using Cedesistemas.Api.Models;

namespace Cedesistemas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly CedesistemasDbContext _context;

        public RestaurantesController(CedesistemasDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante()
        {
            return await _context.Restaurante.ToListAsync();
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(Guid id)
        {
            var restaurante = await _context.Restaurante.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}/Productos")]
        public async Task<ActionResult<List<Producto>>> GetProductos(Guid id)
        {
            var productos = await _context.Producto.Where(x=> x.RestauranteId== id).ToListAsync();

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Restaurantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(Guid id, Restaurante restaurante)
        {
            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
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

        // POST: api/Restaurantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            _context.Restaurante.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurante", new { id = restaurante.Id }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurante>> DeleteRestaurante(Guid id)
        {
            var restaurante = await _context.Restaurante.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurante.Remove(restaurante);
            await _context.SaveChangesAsync();

            return restaurante;
        }

        private bool RestauranteExists(Guid id)
        {
            return _context.Restaurante.Any(e => e.Id == id);
        }
    }
}
