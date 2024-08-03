using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuessController : ControllerBase
    {
         readonly IMemoryCache _memoryCache;

        public ValuessController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet("set/{name}")]
        //public void Set(string name)
        //{
        //    _memoryCache.Set("name", "muhammed");


        //}

        //[HttpGet]
        //public string Get()
        //{
        //    if(_memoryCache.TryGetValue("name",out string name))
        //    {
        //        return name.Substring(3);
        //    }
        //    return "";
        //    //return _memoryCache.Get<strin   g>("name");
        //}
        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration=TimeSpan.FromSeconds(5)
            });


    }
        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");  

        }







    }

    

}