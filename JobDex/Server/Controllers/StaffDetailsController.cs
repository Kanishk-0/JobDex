using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobDex.Server.Data;
using JobDex.Shared.Domain;
using JobDex.Server.IRepository;

namespace JobDex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffDetailsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public StaffDetailsController(ApplicationDbContext context)
        public StaffDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/StaffDetails
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<StaffDetails>>> GetStaffDetailss()
        public async Task<ActionResult> GetStaffDetailss()
        {
            //return await _context.StaffDetailss.ToListAsync();
            var staffDetailss = await _unitOfWork.StaffDetailss.GetAll();
            return Ok(staffDetailss);
        }

        // GET: api/StaffDetails/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<StaffDetails>> GetStaffDetails(int id)
        public async Task<ActionResult> GetStaffDetails(int id)
        {
            //var StaffDetails = await _context.StaffDetailss.FindAsync(id);
            var staffDetails = await _unitOfWork.StaffDetailss.Get(q => q.Id == id);

            if (staffDetails == null)
            {
                return NotFound();
            }
            //refactored
            return Ok(staffDetails);
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
            //refactored
            //_context.Entry(StaffDetails).State = EntityState.Modified;
            _unitOfWork.StaffDetailss.Update(staffDetails);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StaffDetailsExists(id))
                if (!await StaffDetailsExists(id))

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

            //_context.StaffDetailss.Add(StaffDetails);
            //await _context.SaveChangesAsync();
            await _unitOfWork.StaffDetailss.Insert(staffDetails);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaffDetails", new { id = staffDetails.Id }, staffDetails);
        }

        // DELETE: api/StaffDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffDetails(int id)
        {
            //var StaffDetails = await _context.StaffDetailss.FindAsync(id);
            var staffDetails = await _unitOfWork.StaffDetailss.Get(q => q.Id == id);
            if (staffDetails == null)
            {
                return NotFound();
            }

            //_context.StaffDetailss.Remove(StaffDetails);
            //await _context.SaveChangesAsync();
            await _unitOfWork.StaffDetailss.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool StaffDetailsExists(int id)
        private async Task<bool> StaffDetailsExists(int id)
        {
            //return _context.StaffDetailss.Any(e => e.Id == id);
            var staffDetails = await _unitOfWork.StaffDetailss.Get(q => q.Id == id);
            return staffDetails != null;
        }
    }
}
