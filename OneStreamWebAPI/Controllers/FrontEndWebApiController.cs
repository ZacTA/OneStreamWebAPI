using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OneStreamWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndWebApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public FrontEndWebApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultApi2 = await CallApi2Async();
            var resultApi3 = await CallApi3Async();

            return Ok(new { ResultFromApi2 = resultApi2, ResultFromApi3 = resultApi3 });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            // Handle POST data and process as needed

            var resultApi2 = await CallApi2Async();
            var resultApi3 = await CallApi3Async();

            return Ok(new { ResultFromApi2 = resultApi2, ResultFromApi3 = resultApi3 });
        }

        private async Task<string> CallApi2Async()
        {
            // Artificial delay in API2
            await Task.Delay(TimeSpan.FromSeconds(5));

            var response = await _httpClient.GetStringAsync("https://web.api2.com");
            return response;
        }

        private async Task<string> CallApi3Async()
        {
            // Artificial delay in API3
            await Task.Delay(TimeSpan.FromSeconds(5));

            var response = await _httpClient.GetStringAsync("https://web.api3.com");
            return response;
        }
    }
}
