using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class ShopOwner:Person
    {
        private ShopList shopList;
        [DataMember]
        public ShopList ShopList { get => shopList; set => shopList = value; }
    }
}
