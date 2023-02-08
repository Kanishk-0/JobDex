using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDex.Shared.Domain
{
    public class Jobs : BaseDomainModel
    {
        public string JobName { get; set; }
        public string JobVacancy { get; set; }
        public string JobDesc { get; set; }
        public string JobSalary { get; set; }
        public string JobIndusty { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company{ get; set; }


    }
}