using JobDex.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Server.Configurations.Entities
{
    public class StaffDetailsSeedConfigurations : IEntityTypeConfiguration<StaffDetails>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StaffDetails> builder)
        {
            builder.HasData(
                new StaffDetails
                {
                    Id = 1,
                    StaffName = "Marcus",
                    StaffPwd = "Marcus0111",
                    StaffNo = 91696420,
                    StaffEmail = "Marcus5513@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new StaffDetails
                {
                    Id = 2,
                    StaffName = "Jyaie",
                    StaffPwd = "Jyaie0111",
                    StaffNo = 91683495,
                    StaffEmail = "Jyaie@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                }
                );
           
        }
    }
}
