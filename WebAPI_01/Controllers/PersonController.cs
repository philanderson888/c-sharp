using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI01.Models;
using System.Collections;


namespace WebAPI01.Controllers
{
    public class PersonController : ApiController
    {
        #region GET ALL PEOPLE AND RETURN A LIST OF PEOPLE
        // GET: api/Person
        public List<Person> Get()
        {
            PersonPersistence pp = new PersonPersistence();
            return pp.getPersons();
        }
        #endregion
        #region GET ONE PERSON
        // GET: api/Person/5
        public Person Get(long id)
        {

            PersonPersistence pp = new PersonPersistence();
            Person p01 = pp.getPerson(id);
           // var p01 = new Person();
          //  p01.FirstName = "Phil";
            return p01;
            
        }
        #endregion
        #region INSERT ONE NEW PERSON AND RETURN BOTH LONG ID AND EMBED IT INSIDE HTTP RESPONSE
        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonPersistence pp = new PersonPersistence();
            long id;
            id = pp.savePerson(value);
            System.Diagnostics.Trace.WriteLine("id is " + id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri,string.Format("person/{0}", id));
            return response;
        }
        #endregion
        #region UPDATE ONE PERSON
        // PUT: api/Person/5
        public HttpResponseMessage Put(long id, [FromBody]Person personBeingUpdated)
        {
            var pp = new PersonPersistence();
            bool recordExists = false;
            recordExists = pp.updatePerson(id, personBeingUpdated);
            HttpResponseMessage response;
            if (recordExists)
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Phil", personBeingUpdated.FirstName);
                
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
        #endregion
        #region DELETE ONE PERSON AND RETURN HTTP RESPONSE DEPENDING ON WHETHER RECORD FOUND OR NOT
        // DELETE: api/Person/5
        public HttpResponseMessage Delete(long id)
        {
            var pp = new PersonPersistence();
            bool recordExisted = false;
            recordExisted = pp.deletePerson(id);
            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
        #endregion
    }
}
