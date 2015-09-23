using AdventureWorks.Mobile.Services._001_Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AdventureWorks.Mobile.Services._002_Infra.EF.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {

        public UserMap()
        {
            ToTable("USERS", "DBO");

            HasKey(x => new { x.UserNumber });

            Property(x => x.UserNumber).HasColumnName("ID");

            Property(x => x.FirstName).HasColumnName("FIRSTNAME");
            Property(x => x.LastName).HasColumnName("LASTNAME");
            Property(x => x.MobileNumber).HasColumnName("MOBILENUMBER");
            Property(x => x.Password).HasColumnName("PASSWORD");
            Property(x => x.CreatedDate).HasColumnName("DATE_CREATED");
            Property(x => x.LastUpdated).HasColumnName("LAST_UPDATED");
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.EmailAddress).HasColumnName("EMAIL");

            Property(x => x.StreetAddress).HasColumnName("STREETADDRESS");
            Property(x => x.Landmark).HasColumnName("LANDMARK");
            Property(x => x.City).HasColumnName("CITY");
            Property(x => x.Pincode).HasColumnName("PINCODE");
            
        }
    }
}