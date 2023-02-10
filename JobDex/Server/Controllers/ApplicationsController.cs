using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobDex.Server.Data;
using JobDex.Shared.Domain;

namespace JobDex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Applications>> GetApplications(int id)
        {
            var Applications = await _context.Applications.FindAsync(id);

            if (Applications == null)
            {
                return NotFound();
            }

            return Applications;
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplications(int id, Applications Applications)
        {
            if (id != Applications.Id)
            {
                return BadRequest();
            }

            _context.Entry(Applications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Applications>> PostApplications(Applications Applications)
        {
            _context.Applications.Add(Applications);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplications", new { id = Applications.Id }, Applications);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplications(int id)
        {
            var Applications = await _context.Applications.FindAsync(id);
            if (Applications == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(Applications);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationsExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
