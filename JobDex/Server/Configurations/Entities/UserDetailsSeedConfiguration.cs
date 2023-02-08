using JobDex.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Server.Configurations.Entities
{
    public class UserDetailsSeedConfiguration : IEntityTypeConfiguration<UserDetails>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserDetails> builder)
        {
            builder.HasData(
               new UserDetails
               {
                   Id = 1,
                   UserName = "Kanishk",
                   UserEmail = "kanishkkp5513@gmail.com",
                   UserNo = 97814201,
                   UserAddress = "Punggol",
                   UserCStatus = "PR",
                   UserEstatus = "Employed",
                   UserDOB = new DateTime(2004, 11, 1),
                   UserPwd = "Kanu0111",
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   CreatedBy = "System",
                   UpdatedBy = "System"

               },
               new UserDetails
               {
                   Id = 2,
                   UserName = "Marcus",
                   UserEmail = "MarcusYong@gmail.com",
                   UserNo = 97823452,
                   UserAddress = "PasirRis",
                   UserCStatus = "Citizen",
                   UserEstatus = "Unemployed",
                   UserDOB = new DateTime(2004, 04, 3),
                   UserPwd = "Marcus0111",
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   CreatedBy = "System",
                   UpdatedBy = "System"
               }

                ) ;
        }
    }
}
