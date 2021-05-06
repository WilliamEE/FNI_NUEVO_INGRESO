using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FNI_CAPTURA_INFORMACION.Modelos;

namespace FNI_CAPTURA_INFORMACION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FniSolicitudInicialController : ControllerBase
    {
        private readonly SUEESContext _context;

        public FniSolicitudInicialController(SUEESContext context)
        {
            _context = context;
        }

        // GET: api/FniSolicitudInicials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FniSolicitudInicial>>> GetFniSolicitudInicials()
        {
            return await _context.FniSolicitudInicials.ToListAsync();
        }

        // GET: api/FniSolicitudInicials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FniSolicitudInicial>> GetFniSolicitudInicial(int id)
        {
            var fniSolicitudInicial = await _context.FniSolicitudInicials.FindAsync(id);

            if (fniSolicitudInicial == null)
            {
                return NotFound();
            }

            return fniSolicitudInicial;
        }

        // PUT: api/FniSolicitudInicials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFniSolicitudInicial(int id, FniSolicitudInicial fniSolicitudInicial)
        {
            if (id != fniSolicitudInicial.Correlativo)
            {
                return BadRequest();
            }

            _context.Entry(fniSolicitudInicial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FniSolicitudInicialExists(id))
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

        // POST: api/FniSolicitudInicials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FniSolicitudInicial>> PostFniSolicitudInicial(FniSolicitudInicial fniSolicitudInicial)
        {
            _context.FniSolicitudInicials.Add(fniSolicitudInicial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFniSolicitudInicial", new { id = fniSolicitudInicial.Correlativo }, fniSolicitudInicial);
        }

        // DELETE: api/FniSolicitudInicials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFniSolicitudInicial(int id)
        {
            var fniSolicitudInicial = await _context.FniSolicitudInicials.FindAsync(id);
            if (fniSolicitudInicial == null)
            {
                return NotFound();
            }

            _context.FniSolicitudInicials.Remove(fniSolicitudInicial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FniSolicitudInicialExists(int id)
        {
            return _context.FniSolicitudInicials.Any(e => e.Correlativo == id);
        }
    }
}
