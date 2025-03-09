using Microsoft.AspNetCore.Mvc;
using SimpleRetryMechanism.Helpers;

namespace SimpleRetryMechanism.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var executeWithRetry = await RetryHelper.ExecuteWithRetry(GetFileData,
                    3, TimeSpan.FromSeconds(2));
                return Ok(executeWithRetry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<string> GetFileData()
        {
            var readFile = await System.IO.File.ReadAllTextAsync("hello.txt");
            return readFile + " test";
        }
    }
}
