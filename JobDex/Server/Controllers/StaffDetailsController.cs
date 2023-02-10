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
    public class StaffDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDetails>>> GetStaffDetails()
        {
            return await _context.StaffDetails.ToListAsync();
        }

        // GET: api/StaffDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDetails>> GetStaffDetails(int id)
        {
            var staffDetails = await _context.StaffDetails.FindAsync(id);

            if (staffDetails == null)
            {
                return NotFound();
            }

            return staffDetails;
        }

        // PUT: api/StaffDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffDetails(int id, StaffDetails staffDetails)
        {
            if (id != staffDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffDetailsExists(id))
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

        // POST: api/StaffDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffDetails>> PostStaffDetails(StaffDetails staffDetails)
        {
            _context.StaffDetails.Add(staffDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffDetails", new { id = staffDetails.Id }, staffDetails);
        }

        // DELETE: api/StaffDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffDetails(int id)
        {
            var staffDetails = await _context.StaffDetails.FindAsync(id);
            if (staffDetails == null)
            {
                return NotFound();
            }

            _context.StaffDetails.Remove(staffDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffDetailsExists(int id)
        {
            return _context.StaffDetails.Any(e => e.Id == id);
        }
    }
}
