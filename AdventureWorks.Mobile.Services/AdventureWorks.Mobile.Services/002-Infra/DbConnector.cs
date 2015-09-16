using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdventureWorks.Mobile.Services._001_Domain;
using AdventureWorks.Mobile.Services.util;

namespace AdventureWorks.Mobile.Services._002_Infra
{
    public class DbConnector
    {
        private readonly string _connectionstring;

        public DbConnector()
        {
            _connectionstring = ConfigurationManager.AppSettings["AzureConnectionString"];
        }

        public UserProfile GetProfile(decimal userId)
        {
            var profile = new UserProfile();
            using (var connection = new SqlConnection(_connectionstring))
            {

                connection.Open();
                var command = new SqlCommand(string.Format("select * from userprofile where  id = {0}", userId)
                                             , connection);
                var ds = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var data = ds.Tables[0].Rows[0];
                        profile.Id = data.AsDecimal("userid");
                        profile.StreetAddress = data.AsString("streetaddress");
                        profile.Landmark = data.AsString("landmark");
                        profile.City = data.AsString("city");
                        profile.State = data.AsString("state");
                        profile.Pincode = data.AsDecimal("pincode");
                    }
                }
            }
            return profile;
        }

        public AuthenticationResult Authenticate(decimal mobileNumber, string password)
        {
            var result = new AuthenticationResult
                {
                    Profile = new UserProfile()
                };
            
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = new SqlCommand(string.Format("select * from users where mobilenumber = {0} and password = '{1}'", mobileNumber, password)
                    , connection);
                var ds = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var data = ds.Tables[0].Rows[0];
                        if (password == data.AsString("password") && mobileNumber == data.AsDecimal("mobilenumber"))
                        {
                            result.IsSuccess = true;
                            result.Profile = GetProfile(data.AsDecimal("id"));
                            result.Profile.UserName = string.Format("{0} {1}", data.AsString("firstname"),
                                                                    data.AsString("lastname"));
                        }
                    }
                }
            }
            
            return result;

        }
    }
}