using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Threading.Tasks;

namespace DistributedCache_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuessController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        public ValuessController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("set")]
        public async Task<IActionResult> Set(string name, string surname)
        {
            // Redis'e veri ekleme
             await _distributedCache.SetStringAsync("name", name, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
             await _distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(surname) , options:new()
            {

                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)

            } );
            return Ok("Values set in cache.");
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            // Redis'ten veriyi alma
            var name = await _distributedCache.GetStringAsync("name");
            var surnameBinary = await _distributedCache.GetAsync("surname");

            // Byte dizisini string'e dönüştürme
            var surname = Encoding.UTF8.GetString(surnameBinary);

            return Ok(new
            {
                name,
                surname
            });
        }
    }
}
