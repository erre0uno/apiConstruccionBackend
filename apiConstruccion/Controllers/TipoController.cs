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
    public class TipoController : ControllerBase
    {
        private readonly InspeccionDbContext _context;

        public TipoController(InspeccionDbContext context)
        {
            _context = context;
        }
        
        // GET: api/<TipoInspeccionController>
        [HttpGet]
        public async Task<IEnumerable<TipoInspeccion>> GetAll()
        {
            return await _context.TipoInspeccions.ToListAsync();
        }

        // GET api/<TipoInspeccionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInspeccion>> GetbyId(int id)
        {
            var tipo = await _context.TipoInspeccions.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        // POST api/<TipoInspeccionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoInspeccion tipo)
        {
            _context.TipoInspeccions.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = tipo.Id }, tipo);
        }

        // PUT api/<TipoInspeccionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoInspeccion tipo)
        {
            if (id != tipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoExists(id))
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
        public async Task<ActionResult<TipoInspeccion>> Delete(int id)
        {
            var tipo = await _context.TipoInspeccions.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.TipoInspeccions.Remove(tipo);
            await _context.SaveChangesAsync();

            return tipo;
        }
        private bool tipoExists(int id)
        {
            return _context.TipoInspeccions.Any(e => e.Id == id);
        }

    }
}
