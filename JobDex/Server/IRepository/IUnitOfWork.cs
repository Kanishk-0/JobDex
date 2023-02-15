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
        IGenericRepository<UserDetails> UserDetailss { get; }
        IGenericRepository<StaffDetails> StaffDetailss { get; }
        IGenericRepository<Applications> Applicationss { get; }
        IGenericRepository<Company> Companiess { get; }
        IGenericRepository<Jobs> Jobss { get; }
    }

}