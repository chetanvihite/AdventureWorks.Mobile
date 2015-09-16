using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AdventureWorks.Services._001_Domain;

namespace AdventureWorks.Services.Controllers
{
    [Route("api/[controller]")]
    public class AdventureWorksController : Controller
    {
        // GET: api/values
        [HttpGet]
        public AuthenticationResult Authenticate(decimal mobileNumber, string password)
        {
            return new AuthenticationResult();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
