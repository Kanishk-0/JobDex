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
        private readonly IUnitOfWork _unitOfWork;

        public StaffDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/StaffDetails
        [HttpGet]
        public async Task<IActionResult> GetStaffDetails()
        {
            var StaffDetails = await _unitOfWork.StaffDetails.GetAll();
            return Ok(StaffDetails);
        }

        // GET: api/StaffDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffDetails(int id)
        {
            var staffDetail = await _unitOfWork.StaffDetails.Get(q => q.Id == id);

            if (staffDetail == null)
            {
                return NotFound();
            }

            return Ok(staffDetail);
        }

        // PUT: api/StaffDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffDetails(int id, StaffDetails StaffDetails)
        {
            if (id != StaffDetails.Id)
            {
                return BadRequest();
            }

            _unitOfWork.StaffDetails.Update(StaffDetails);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StaffDetailExists(id))
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
        public async Task<ActionResult<StaffDetails>> PostStaffDetails(StaffDetails StaffDetails)
        {
            await _unitOfWork.StaffDetails.Insert(StaffDetails);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaffDetails", new { id = StaffDetails.Id }, StaffDetails);
        }

        // DELETE: api/StaffDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffDetails(int id)
        {
            var StaffDetails = await _unitOfWork.StaffDetails.Get(q => q.Id == id);
            if (StaffDetails == null)
            {
                return NotFound();
            }

            await _unitOfWork.StaffDetails.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> StaffDetailExists(int id)
        {
            var staffDetail = await _unitOfWork.StaffDetails.Get(q => q.Id == id);
            return staffDetail != null;
        }
    }
}
