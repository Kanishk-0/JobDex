using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDex.Shared.Domain
{
    public class UserDetails : BaseDomainModel
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserNo { get; set; }
        public string UserAddress { get; set; }
        public string UserCStatus { get; set; }
        public DateTime UserDOB { get; set; }
        public string UserEstatus { get; set; }
        public string UserPwd { get; set; }
        
        
    }
}
