using JobDex.Server.Data;
using JobDex.Server.IRepository;
using JobDex.Server.Models;
using JobDex.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobDex.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<UserDetails> _userDetails;
        private IGenericRepository<StaffDetails> _staffDetails;
        private IGenericRepository<Applications> _applications;
        private IGenericRepository<Company> _companies;
        private IGenericRepository<Jobs> _jobs;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<UserDetails> UserDetailss
            => _userDetails ??= new GenericRepository<UserDetails>(_context);
        public IGenericRepository<StaffDetails> StaffDetailss
            => _staffDetails ??= new GenericRepository<StaffDetails>(_context);
        public IGenericRepository<Applications> Applicationss
            => _applications ??= new GenericRepository<Applications>(_context);
        public IGenericRepository<Company> Companiess
            => _companies ??= new GenericRepository<Company>(_context);
        public IGenericRepository<Jobs> Jobss
            => _jobs ??= new GenericRepository<Jobs>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
