using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Company:BaseEntity
    {
        private DriverList drivers;
        private string name;
        [DataMember]
        public DriverList Drivers { get => drivers; set => drivers = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
    }
}
