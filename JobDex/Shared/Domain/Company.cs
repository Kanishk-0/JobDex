using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDex.Shared.Domain
{
    public class Company :  BaseDomainModel
    {
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public int CompanyNo { get; set; }
        public string CompanyPwd { get; set; }
        public string CompanyDesc { get; set; }

    }
}
