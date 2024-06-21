using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusLineList:List<BusLine>
    {
        public BusLineList() { }

        public BusLineList(IEnumerable<BusLine> list) : base(list) { }

        public BusLineList(IEnumerable<BaseEntity> list) : base(list.Cast<BusLine>().ToList()) { }
    }
}
