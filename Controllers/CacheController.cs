using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        public CacheController(IDatabase database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public IDatabase Database { get; }

        // GET: api/Cache/5
        [HttpGet]
        public string Get([FromQuery] string key)
        {
            var result = Database.StringGet(key);

            return result;
        }

        // POST: api/Cache
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> keyValue)
        {
            Database.StringSet(keyValue.Key, keyValue.Value);
        }
    }
}
