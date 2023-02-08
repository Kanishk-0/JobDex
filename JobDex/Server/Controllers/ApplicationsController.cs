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
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var Applications = await _unitOfWork.Applications.GetAll();
            return Ok(Applications);
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplications(int id)
        {
            var application = await _unitOfWork.Applications.Get(q => q.Id == id);

            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
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

            _unitOfWork.Applications.Update(Applications);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ApplicationExists(id))
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
            await _unitOfWork.Applications.Insert(Applications);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetApplications", new { id = Applications.Id }, Applications);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplications(int id)
        {
            var Applications = await _unitOfWork.Applications.Get(q => q.Id == id);
            if (Applications == null)
            {
                return NotFound();
            }

            await _unitOfWork.Applications.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ApplicationExists(int id)
        {
            var application = await _unitOfWork.Applications.Get(q => q.Id == id);
            return application != null;
        }
    }
}
