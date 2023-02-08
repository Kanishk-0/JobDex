using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDex.Shared.Domain
{
    public class StaffDetails : BaseDomainModel
    {
        public string StaffName { get; set; }
        public string StaffPwd { get; set; }
        public int StaffNo { get; set; }
        public string StaffEmail{ get; set; }
    }
}
