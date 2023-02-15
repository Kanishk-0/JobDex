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
    public class ApplicationsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ApplicationsController(ApplicationDbContext context)
        public ApplicationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Applications
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Applications>>> GetApplicationss()
        public async Task<ActionResult> GetApplicationss()
        {
            //return await _context.Applicationss.ToListAsync();
            var Applicationss = await _unitOfWork.Applicationss.GetAll();
            return Ok(Applicationss);
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Applications>> GetApplications(int id)
        public async Task<ActionResult> GetApplications(int id)
        {
            //var Applications = await _context.Applicationss.FindAsync(id);
            var Applications = await _unitOfWork.Applicationss.Get(q => q.Id == id);

            if (Applications == null)
            {
                return NotFound();
            }
            //refactored
            return Ok(Applications);
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
            //refactored
            //_context.Entry(Applications).State = EntityState.Modified;
            _unitOfWork.Applicationss.Update(Applications);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ApplicationsExists(id))
                if (!await ApplicationsExists(id))

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

            //_context.Applicationss.Add(Applications);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Applicationss.Insert(Applications);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetApplications", new { id = Applications.Id }, Applications);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplications(int id)
        {
            //var Applications = await _context.Applicationss.FindAsync(id);
            var Applications = await _unitOfWork.Applicationss.Get(q => q.Id == id);
            if (Applications == null)
            {
                return NotFound();
            }

            //_context.Applicationss.Remove(Applications);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Applicationss.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ApplicationsExists(int id)
        private async Task<bool> ApplicationsExists(int id)
        {
            //return _context.Applicationss.Any(e => e.Id == id);
            var Applications = await _unitOfWork.Applicationss.Get(q => q.Id == id);
            return Applications != null;
        }
    }
}