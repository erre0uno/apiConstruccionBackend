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
    public class EstadosController : ControllerBase
    {
        private readonly InspeccionDbContext _context;

        public EstadosController(InspeccionDbContext context) {
            _context = context;
        }


        // GET: api/<EstadosController>
        [HttpGet]
        public async Task<IEnumerable<Estado>> GetAll()
        {
            return await _context.Estados.ToListAsync();
        }

        // GET api/<EstadosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetbyId(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // POST api/<EstadosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = estado.Id }, estado);
        }

        // PUT api/<EstadosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Estado estado)
        {
            if (id != estado.Id)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estadoExists(id))
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

        // DELETE api/<EstadosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return estado;
        }

        private bool estadoExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }


    }
}
