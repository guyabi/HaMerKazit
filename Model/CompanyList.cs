using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CompanyList:List<Company>
    {
        public CompanyList() { }

        public CompanyList(IEnumerable<Company> list) : base(list) { }

        public CompanyList(IEnumerable<BaseEntity> list) : base(list.Cast<Company>().ToList()) { }
    }
}
