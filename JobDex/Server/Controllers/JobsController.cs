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
    public class JobsController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public JobsController(ApplicationDbContext context)
        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Jobs>>> GetJobss()
        public async Task<ActionResult> GetJobss()
        {
            //return await _context.Jobss.ToListAsync();
            var Jobss = await _unitOfWork.Jobss.GetAll();
            return Ok(Jobss);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Jobs>> GetJobs(int id)
        public async Task<ActionResult> GetJobs(int id)
        {
            //var Jobs = await _context.Jobss.FindAsync(id);
            var Jobs = await _unitOfWork.Jobss.Get(q => q.Id == id);

            if (Jobs == null)
            {
                return NotFound();
            }
            //refactored
            return Ok(Jobs);
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobs(int id, Jobs Jobs)
        {
            if (id != Jobs.Id)
            {
                return BadRequest();
            }
            //refactored
            //_context.Entry(Jobs).State = EntityState.Modified;
            _unitOfWork.Jobss.Update(Jobs);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!JobsExists(id))
                if (!await JobsExists(id))

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

        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobs>> PostJobs(Jobs Jobs)
        {

            //_context.Jobss.Add(Jobs);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Jobss.Insert(Jobs);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetJobs", new { id = Jobs.Id }, Jobs);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobs(int id)
        {
            //var Jobs = await _context.Jobss.FindAsync(id);
            var Jobs = await _unitOfWork.Jobss.Get(q => q.Id == id);
            if (Jobs == null)
            {
                return NotFound();
            }

            //_context.Jobss.Remove(Jobs);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Jobss.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool JobsExists(int id)
        private async Task<bool> JobsExists(int id)
        {
            //return _context.Jobss.Any(e => e.Id == id);
            var Jobs = await _unitOfWork.Jobss.Get(q => q.Id == id);
            return Jobs != null;
        }
    }
}
