using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FNI_CAPTURA_INFORMACION.ModelosClass;

namespace FNI_CAPTURA_INFORMACION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelesController : ControllerBase
    {
        private readonly CLASS_UEESContext _context;

        public NivelesController(CLASS_UEESContext context)
        {
            _context = context;
        }

        /// <summary>
        /// William Rosales
        /// Método para obtener las carreras ofertadas para ese periodo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Niveles>>> GetNiveles()
        {
            var carreras_ofertadas = _context.NiCarrerasOfertadas.Where(c => c.EstadoNi == "S").Select(c => c.Idcarrera);
            var niveles = await _context.Niveles
                .Where(x => x.Nivcod != "0000" && x.Nivcod != "0558" && x.Nivcla == "1" && x.Nivcar != "11" && !x.Nivdsc.StartsWith("CURSO") && carreras_ofertadas.Contains(x.Nivcod))
                .OrderBy(x => x.Nivdsc)
                .ToListAsync();

            return niveles;
        }

        //// GET: api/Niveles/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Niveles>> GetNiveles(string id)
        //{
        //    var niveles = await _context.Niveles.FindAsync(id);

        //    if (niveles == null)
        //    {
        //        return NotFound();
        //    }

        //    return niveles;
        //}

        //// PUT: api/Niveles/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNiveles(string id, Niveles niveles)
        //{
        //    if (id != niveles.Nivcod)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(niveles).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NivelesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Niveles
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Niveles>> PostNiveles(Niveles niveles)
        //{
        //    _context.Niveles.Add(niveles);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (NivelesExists(niveles.Nivcod))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetNiveles", new { id = niveles.Nivcod }, niveles);
        //}

        //// DELETE: api/Niveles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteNiveles(string id)
        //{
        //    var niveles = await _context.Niveles.FindAsync(id);
        //    if (niveles == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Niveles.Remove(niveles);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool NivelesExists(string id)
        //{
        //    return _context.Niveles.Any(e => e.Nivcod == id);
        //}
    }
}
