using JobDex.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Server.Configurations.Entities
{
    public class ApplicationSeedConfiguration : IEntityTypeConfiguration<Applications>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Applications> builder)
        {
            builder.HasData(
                new Applications
                {
                    Id = 1,
                    UserDetailsId = 1,
                    StaffDetailsId = 1,
                    JobsId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "User",
                    UpdatedBy = "User"
                },
                new Applications
                {
                    Id = 2,
                    UserDetailsId = 2,
                    StaffDetailsId = 2,
                    JobsId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "User",
                    UpdatedBy = "User"
                }
            );
        }
    }
}