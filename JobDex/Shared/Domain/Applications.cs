using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDex.Shared.Domain
{
    public class Applications : BaseDomainModel
    {
        public int UserDetailsId { get; set; }
        public int StaffDetailsId { get; set; }
        public int JobsId { get; set; }
    }
}
