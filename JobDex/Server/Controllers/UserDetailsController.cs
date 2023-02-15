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
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public UserDetailsController(ApplicationDbContext context)
        public UserDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetailss()
        public async Task<ActionResult> GetUserDetailss()
        {
            //return await _context.UserDetailss.ToListAsync();
            var userDetailss = await _unitOfWork.UserDetailss.GetAll();
            return Ok(userDetailss);
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
        public async Task<ActionResult> GetUserDetails(int id)
        {
            //var userDetails = await _context.UserDetailss.FindAsync(id);
            var userDetails = await _unitOfWork.UserDetailss.Get(q => q.Id == id);

            if (userDetails == null)
            {
                return NotFound();
            }
            //refactored
            return Ok(userDetails);
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
            //refactored
            //_context.Entry(userDetails).State = EntityState.Modified;
            _unitOfWork.UserDetailss.Update(userDetails);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!UserDetailsExists(id))
                if (!await UserDetailsExists(id))

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

            //_context.UserDetailss.Add(userDetails);
            //await _context.SaveChangesAsync();
            await _unitOfWork.UserDetailss.Insert(userDetails);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUserDetails", new { id = userDetails.Id }, userDetails);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            //var userDetails = await _context.UserDetailss.FindAsync(id);
            var userDetails = await _unitOfWork.UserDetailss.Get(q => q.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            //_context.UserDetailss.Remove(userDetails);
            //await _context.SaveChangesAsync();
            await _unitOfWork.UserDetailss.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool UserDetailsExists(int id)
        private async Task<bool> UserDetailsExists(int id)
        {
            //return _context.UserDetailss.Any(e => e.Id == id);
            var userDetails = await _unitOfWork.UserDetailss.Get(q => q.Id == id);
            return userDetails != null;
        }
    }
}
