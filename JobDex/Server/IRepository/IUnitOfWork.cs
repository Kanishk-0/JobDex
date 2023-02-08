using JobDex.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JobDex.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<UserDetails> UserDetails { get; }
        IGenericRepository<StaffDetails> StaffDetails { get; }
        IGenericRepository<Applications> Applications { get; }
        IGenericRepository<Company> Companies { get; }
        IGenericRepository<Jobs> Jobs { get; }
    }

}