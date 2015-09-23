using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdventureWorks.Mobile.Services._001_Domain
{
    public class User : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MobileNumber { get; set; }

        public string Password { get; set; }
       
        public string Active { get; set; }

        public string EmailAddress { get; set; }

        public string StreetAddress { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Int64? Pincode { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}