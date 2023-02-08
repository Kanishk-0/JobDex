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
    public class UserDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var userdetails = await _unitOfWork.UserDetails.GetAll();
            return Ok(userdetails);
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var userdetail = await _unitOfWork.UserDetails.Get(q => q.Id == id);

            if (userdetail == null)
            {
                return NotFound();
            }

            return Ok(userdetail);
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return BadRequest();
            }

            _unitOfWork.UserDetails.Update(userDetails);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserDetailExists(id))
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

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetails>> PostUserDetails(UserDetails userDetails)
        {
            await _unitOfWork.UserDetails.Insert(userDetails);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUserDetails", new { id = userDetails.Id }, userDetails);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            var userDetails = await _unitOfWork.UserDetails.Get(q => q.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            await _unitOfWork.UserDetails.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> UserDetailExists(int id)
        {
            var userDetail = await _unitOfWork.UserDetails.Get(q => q.Id == id);
            return userDetail != null;
        }
    }
}
