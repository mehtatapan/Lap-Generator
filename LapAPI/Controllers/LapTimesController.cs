#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LapAPI.Data;
using LapAPI.Models;

namespace LapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapTimesController : ControllerBase
    {
        private readonly LapDataContext _context;

        public LapTimesController(LapDataContext context)
        {
            _context = context;
        }

        // GET: api/LapTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LapTime>>> GetLapTimes()
        {
            return await _context.LapTimes
                .Include(p => p.Driver)
                .ToListAsync();
        }

        // GET: api/LapTimes
        [HttpGet("ByDriver/{id}")]
        public async Task<ActionResult<IEnumerable<LapTime>>> GetLapTimesByDriver(int id)
        {
            return await _context.LapTimes
                .Include(p => p.Driver)
                .Where(p => p.DriverID == id)
                .ToListAsync();
        }

        // GET: api/LapTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LapTime>> GetLapTime(int id)
        {
            var lapTime = await _context.LapTimes
                .Include(p=>p.Driver)
                .FirstOrDefaultAsync(p=>p.ID == id);

            if (lapTime == null)
            {
                return NotFound();
            }

            return lapTime;
        }

        // PUT: api/LapTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLapTime(int id, LapTime lapTime)
        {
            if (id != lapTime.ID)
            {
                return BadRequest();
            }

            _context.Entry(lapTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LapTimeExists(id))
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

        // POST: api/LapTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LapTime>> PostLapTime(LapTime lapTime)
        {
            _context.LapTimes.Add(lapTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLapTime", new { id = lapTime.ID }, lapTime);
        }

        // DELETE: api/LapTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLapTime(int id)
        {
            var lapTime = await _context.LapTimes.FindAsync(id);
            if (lapTime == null)
            {
                return NotFound();
            }

            _context.LapTimes.Remove(lapTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LapTimeExists(int id)
        {
            return _context.LapTimes.Any(e => e.ID == id);
        }
    }
}
