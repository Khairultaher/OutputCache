using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;
using WebApi.OutputCache.V2.TimeAttributes;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {

        [AllowAnonymous]
        [Route("state")]
        public List<string> State()
        {
            List< string> obj = new List<string>();
            obj.Add("Punjab");
            obj.Add("Assam");
            obj.Add("UP");
            obj.Add("AP");
            obj.Add("J&K");
            obj.Add("Odisha");
            obj.Add("Delhi");
            obj.Add("Karnataka");
            obj.Add("Bangalore");
            obj.Add("Rajesthan");
            obj.Add("Jharkhand");
            obj.Add("chennai");
            obj.Add("jammu");
            obj.Add("Bhubaneshwar");
            obj.Add("Delhi");
            obj.Add("Karnataka");

            return obj;
        }

        // GET api/values
        // [CacheOutput(ClientTimeSpan = 240, ServerTimeSpan = 240)]
        [CacheOutputUntilToday(16, 48)]
        public IEnumerable<string> Get()
        {
            // await Task.Delay(100);
            List<string> obj = new List<string>();
            obj.Add("Punjab");
            obj.Add("Assam");
            obj.Add("UP");
            obj.Add("AP");
            obj.Add("J&K");
            obj.Add("Odisha");
            obj.Add("Delhi");
            obj.Add("Karnataka");
            obj.Add("Bangalore");
            obj.Add("Rajesthan");
            obj.Add("Jharkhand");
            obj.Add("chennai");
            obj.Add("jammu");
            obj.Add("Bhubaneshwar");
            obj.Add("Delhi");
            obj.Add("Karnataka");

            return obj;
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
