using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusLine: BaseEntity
    {
        private int Line;
        private string Destination;
        private string Hour;
        private int Price;
        private int companyID;
        private DriverList drivers;
        public int Line1 { get => Line; set => Line = value; }
        public string Destination1 { get => Destination; set => Destination = value; }
        public string Hour1 { get => Hour; set => Hour = value; }
        public int Price1 { get => Price; set => Price = value; }
        public int CompanyID { get => companyID; set => companyID = value; }
        public DriverList Drivers { get => drivers; set => drivers = value; }
    }
}
