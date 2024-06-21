using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class ShopOwnerList: List<ShopOwner>
    {

        public ShopOwnerList() { }

        public ShopOwnerList(IEnumerable<ShopOwner> list) : base(list) { }

        public ShopOwnerList(IEnumerable<BaseEntity> list) : base(list.Cast<ShopOwner>().ToList()) { }
    }
}
