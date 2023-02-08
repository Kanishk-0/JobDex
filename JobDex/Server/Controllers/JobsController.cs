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
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var Jobs = await _unitOfWork.Jobs.GetAll();
            return Ok(Jobs);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobs(int id)
        {
            var job = await _unitOfWork.Jobs.Get(q => q.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
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

            _unitOfWork.Jobs.Update(Jobs);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await JobExists(id))
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
            await _unitOfWork.Jobs.Insert(Jobs);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetJobs", new { id = Jobs.Id }, Jobs);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobs(int id)
        {
            var Jobs = await _unitOfWork.Jobs.Get(q => q.Id == id);
            if (Jobs == null)
            {
                return NotFound();
            }

            await _unitOfWork.Jobs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> JobExists(int id)
        {
            var job = await _unitOfWork.Jobs.Get(q => q.Id == id);
            return job != null;
        }
    }
}
