using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    [KnownType(typeof(Driver))]
    [KnownType(typeof(Passenger))]
    [KnownType(typeof(ShopOwner))]
    public class Person : BaseEntity
    {
        private string firstName;
        private string lastName;
        private string email;
        private City city;
        private string userName;
        private string password;
        private bool IsAdmin;
        [DataMember]
        public string FirstName { get => firstName; set => firstName = value; }
        [DataMember]
        public string LastName { get => lastName; set => lastName = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public City City { get => city; set => city = value; }
        [DataMember]
        public string UserName { get => userName; set => userName = value; }
        [DataMember]
        public string Password1 { get => password; set => password = value; }
        [DataMember]
        public bool IsAdmin1 { get => IsAdmin; set => IsAdmin = value; }
    }
}
