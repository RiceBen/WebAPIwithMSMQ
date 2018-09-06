using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIwithMSMQ.Services;

namespace WebAPIwithMSMQ.Controllers
{
    public class ValuesController : ApiController
    {
        private IQueueService _queueService;

        public ValuesController(IQueueService service)
        {
            this._queueService = service;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            this._queueService.Send(
                new { ID = 1 , Name = "Mr.Queue", Age = 18}
            );
            return new string[] { "value1", "value2" };
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
