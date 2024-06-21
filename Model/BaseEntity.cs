using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    [KnownType(typeof(Person))]
    [KnownType(typeof(City))]
    [KnownType(typeof(Shop))]
    public abstract class BaseEntity
    {
        private int id;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
