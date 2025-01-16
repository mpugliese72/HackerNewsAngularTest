using HackerNewsAngularTest.Server.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;

namespace HackerNewsAngularTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            HttpClient client = new HttpClient();

            try
            {
                _logger.LogInformation($"Initiating request to url.");

                var url = "https://hacker-news.firebaseio.com/v0/item/121003.json? \r\nprint=pretty&orderBy=\"$key\"&limitToFirst=5";

                var response = client.GetAsync(url).Result;

                var responseValues = await response.Content.ReadFromJsonAsync<News>();

                //var responseValues2 = await response.Content.ReadAsStringAsync();
                //News? result = JsonSerializer.Deserialize<News>(responseValues2);

                _logger.LogInformation($"Retrieved results from request. Populating object");

                if (responseValues == null)
                {
                    return NotFound();
                }

                return Ok(Enumerable.Range(1, 1).Select(test => new News()
                {
                    id = responseValues.id,
                    title = responseValues?.title ?? "Missing Title",
                    poll = responseValues?.poll ?? 0,
                    score = responseValues?.score ?? 0,
                    url = responseValues?.url ?? "Missing URL"
                }).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred retrieving stories.", ex);
            }
        }
    }
}
