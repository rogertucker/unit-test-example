using System.Collections.Generic;

namespace DBLayer.Models{

    public class User : BaseModel
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    }
}