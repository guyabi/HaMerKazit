using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Driver:Person
    {
        private int companyID;
        private int busLineID;
        [DataMember]
        public int CompanyID { get => companyID; set => companyID = value; }
        [DataMember]
        public int BusLineID { get => busLineID; set => busLineID = value; }
    }
}
