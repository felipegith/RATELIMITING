using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RATELIMITING.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class LimiterController : ControllerBase
    {
        [HttpGet]
        [Route("FixedWindow")]
        [EnableRateLimiting("fixed")]
        public IActionResult FixedWindowLimiting()
        {
            return Ok("fixed window");
        }

        [HttpGet]
        [Route("SlidingWindow")]
        [EnableRateLimiting("sliding")]
        public IActionResult SlidingWindowLimiting()
        {
            return Ok("sliding window");
        }

        [HttpGet]
        [Route("TokenBucket")]
        [EnableRateLimiting("token")]
        public IActionResult TokenBucketLimiting()
        {
            return Ok("token bucket");
        }

        [HttpGet]
        [Route("Concurrency")]
        [EnableRateLimiting("concurrency")]
        public IActionResult ConcurrencytLimiting()
        {
            return Ok("Concurrency ");
        }
    }
}