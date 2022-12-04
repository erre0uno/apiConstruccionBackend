using apiConstruccion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiConstruccion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InspeccionController : ControllerBase
    {
        private readonly InspeccionDbContext _context;

        public InspeccionController(InspeccionDbContext context)
        {
            _context = context;
        }
        // GET: api/<TipoInspeccionController>
        [HttpGet]
        public async Task<IEnumerable<Inspeccion>> GetAll()
        {
            return await _context.Inspeccions.ToListAsync();
        }

        // GET api/<TipoInspeccionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspeccion>> GetbyId(int id)
        {
            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return inspeccion;
        }


        // POST api/<TipoInspeccionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Inspeccion inspeccion)
        {
            _context.Inspeccions.Add(inspeccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = inspeccion.Id }, inspeccion);
        }

        // PUT api/<TipoInspeccionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Inspeccion inspeccion)
        {
            if (id != inspeccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspeccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inspeccionExists(id))
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
        // DELETE api/<TipoInspeccionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inspeccion>> Delete(int id)
        {
            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            _context.Inspeccions.Remove(inspeccion);
            await _context.SaveChangesAsync();

            return inspeccion;
        }
        private bool inspeccionExists(int id)
        {
            return _context.Inspeccions.Any(e => e.Id == id);
        }
    }
}
