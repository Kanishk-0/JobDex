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
    public class CompaniesController : ControllerBase
    {
        //refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CompaniesController(ApplicationDbContext context)
        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Companies
        [HttpGet]
        //refactored
        //public async Task<ActionResult<IEnumerable<Companies>>> GetCompaniess()
        public async Task<ActionResult> GetCompaniess()
        {
            //return await _context.Companiess.ToListAsync();
            var Companiess = await _unitOfWork.Companiess.GetAll();
            return Ok(Companiess);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        //refactored
        //public async Task<ActionResult<Companies>> GetCompanies(int id)
        public async Task<ActionResult> GetCompanies(int id)
        {
            //var Companies = await _context.Companiess.FindAsync(id);
            var Companies = await _unitOfWork.Companiess.Get(q => q.Id == id);

            if (Companies == null)
            {
                return NotFound();
            }
            //refactored
            return Ok(Companies);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(int id, Company Companies)
        {
            if (id != Companies.Id)
            {
                return BadRequest();
            }
            //refactored
            //_context.Entry(Companies).State = EntityState.Modified;
            _unitOfWork.Companiess.Update(Companies);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CompaniesExists(id))
                if (!await CompaniesExists(id))

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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompanies(Company Companies)
        {

            //_context.Companiess.Add(Companies);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Companiess.Insert(Companies);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCompanies", new { id = Companies.Id }, Companies);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanies(int id)
        {
            //var Companies = await _context.Companiess.FindAsync(id);
            var Companies = await _unitOfWork.Companiess.Get(q => q.Id == id);
            if (Companies == null)
            {
                return NotFound();
            }

            //_context.Companiess.Remove(Companies);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Companiess.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CompaniesExists(int id)
        private async Task<bool> CompaniesExists(int id)
        {
            //return _context.Companiess.Any(e => e.Id == id);
            var Companies = await _unitOfWork.Companiess.Get(q => q.Id == id);
            return Companies != null;
        }
    }
}
