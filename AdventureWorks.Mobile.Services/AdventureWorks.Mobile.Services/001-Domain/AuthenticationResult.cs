using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Mobile.Services._001_Domain
{
    public class AuthenticationResult : BaseResponse
    {
        public User Profile { get; set; }
    }
}