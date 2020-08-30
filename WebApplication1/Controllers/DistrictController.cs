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
    [RoutePrefix("api/district")]
    public class DistrictController : ApiController
    {
        List<string> districts = new List<string>();
        public DistrictController()
        {
            districts.Add("Bagerhat");
            districts.Add("Bandarban");
            districts.Add("Barguna");
            districts.Add("Barisal");
            districts.Add("Bhola");
            districts.Add("Bogra");
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("states")]
        public List<string> State()
        {
            return districts;
        }

        // GET api/district
        // [CacheOutputUntilToday(16, 48)]
        [CacheOutput(ClientTimeSpan = 240, ServerTimeSpan = 240)]
        public IEnumerable<string> Get()
        {
            // await Task.Delay(100);
            return districts;
        }


        // GET api/values/5
        // [CacheOutputUntilToday(16, 48)]
        [CacheOutput(ClientTimeSpan = 240, ServerTimeSpan = 240)]
        public string Get(string id)
        {
            return districts.Where(w=> w.Contains(id)).FirstOrDefault();
        }

        [HttpGet]
        [Route("{name}/byname")]
        // [CacheOutputUntilToday(16, 48)]
        [CacheOutput(ClientTimeSpan = 240, ServerTimeSpan = 240)]
        public string GetByName(string name)
        {
            return districts.Where(w => w.Contains(name)).FirstOrDefault();
        }

        [HttpGet]
        [Route("{name}/byname")]
        // [CacheOutputUntilToday(16, 48)]
        [CacheOutput(ClientTimeSpan = 240, ServerTimeSpan = 240)]
        public string GetByName()
        {
            return "";
        }

        // POST api/district
        [HttpPost]
        [InvalidateCacheOutput("Get")]
        [InvalidateCacheOutput("GetByName")]
        public IHttpActionResult Post([FromBody]string value)
        {
            districts.Add("Faridpur");

            // now get cache instance
            //var cache = Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request);
            //// and invalidate cache for method "Get" of "DistrictController"
            //cache.RemoveStartsWith(Configuration.CacheOutputConfiguration()
            //    .MakeBaseCachekey((DistrictController t) => t.Get()));

            return Ok("OK");

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
