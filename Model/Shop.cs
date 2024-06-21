using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Shop:BaseEntity
    {
        private string Name;
        private bool IsOpen;
        private ShopOwner ShopOwner;
        [DataMember]
        public string Name_ { get => Name; set => Name = value; }
        [DataMember]
        public bool IsOpen_ { get => IsOpen; set => IsOpen = value; }
        [DataMember]
        public ShopOwner ShopOwner_ { get => ShopOwner; set => ShopOwner = value; }
    }
}
