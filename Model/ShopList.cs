using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class ShopList: List<Shop>
    {
        public ShopList() { }

        public ShopList(IEnumerable<Shop> list) : base(list) { }

        public ShopList(IEnumerable<BaseEntity> list) : base(list.Cast<Shop>().ToList()) { }
    }
}
