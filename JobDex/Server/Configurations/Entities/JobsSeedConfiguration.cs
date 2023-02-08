using JobDex.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Server.Configurations.Entities
{
    public class JobsSeedConfiguration : IEntityTypeConfiguration<Jobs>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Jobs> builder)
        {
            builder.HasData(
                new Jobs
                {
                    Id = 1,
                    JobName = "Software Engineer",
                    JobVacancy = "Available",
                    JobDesc = "job",
                    JobSalary = "$3000",
                    JobIndusty = "IT",
                    CompanyId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Jobs
                {
                    Id = 2,
                    JobName = "Software Engineer",
                    JobVacancy = "Available",
                    JobDesc = "job",
                    JobSalary = "$5000",
                    JobIndusty = "Tech",
                    CompanyId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );
        }
    }
}