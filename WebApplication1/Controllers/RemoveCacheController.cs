using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebApplication1.Controllers
{
    public class RemoveCacheController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public IHttpActionResult Post([FromBody]string value)
        {
            // now get cache instance
            var cache = Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request);
            // and invalidate cache for method "Get" of "DistrictController"
            cache.RemoveStartsWith(Configuration.CacheOutputConfiguration()
                .MakeBaseCachekey((DistrictController t) => t.Get()));

            cache.RemoveStartsWith(Configuration.CacheOutputConfiguration()
                .MakeBaseCachekey((DistrictController t) => t.GetByName()));

            return Ok("Removed");
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
