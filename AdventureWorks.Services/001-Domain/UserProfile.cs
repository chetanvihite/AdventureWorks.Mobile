using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Services._001_Domain
{

    public class UserProfile
    {
        public decimal MobileNumber { get; set; }
        public string UserName { get; set; }
        public string StreetAddress { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Pincode { get; set; }

        public string AuthenticationResult { get; set; }

    }
}
