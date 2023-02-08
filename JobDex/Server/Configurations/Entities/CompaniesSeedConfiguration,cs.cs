using JobDex.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Server.Configurations.Entities
{
    public class CompanySeedConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1,
                    CompanyName = "Google Inc.",
                    CompanyEmail = "googleInc@gmail.com",
                    CompanyNo = 64727936,
                    CompanyDesc = "Widely known as your best friend.",
                    CompanyPwd = "googleisgreat",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "Facebook Inc.",
                    CompanyEmail = "FacebookInc@gmail.com",
                    CompanyNo = 64724336,
                    CompanyDesc = "Find friends",
                    CompanyPwd = "Facebook1!",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }

            );
        }
    }
}