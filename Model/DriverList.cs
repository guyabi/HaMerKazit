using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class DriverList:List<Driver>
    {
        public DriverList() { }
        public DriverList(IEnumerable<Driver> list) : base(list) { }
        public DriverList(IEnumerable<BaseEntity> list) : base(list.Cast<Driver>().ToList()) { }
    }
}
