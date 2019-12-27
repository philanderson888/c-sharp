using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ASPDOTNETAPI.Controllers
{
    public class ValuesController : ApiController
    {
        List<Customer> customers = new List<Customer>();
        List<String> customerNames = new List<String>();
        string[] customerNameArray;

        // GET api/values
        public IEnumerable<string> Get()
        {

            using (var db = new NorthwindEntities())
            {
                customers = (db.Customers).ToList<Customer>();
            }
            customers.ForEach(cust => {
                customerNames.Add(cust.ContactName);
                
                });

            customerNameArray = new string[customerNames.Count];

            for (int i = 0; i < customerNames.Count; i++)
            {
                customerNameArray[i] = customerNames[i];
            }

            return customerNameArray;

            // return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
