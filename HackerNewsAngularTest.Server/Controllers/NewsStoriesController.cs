using HackerNewsAngularTest.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAngularTest.Server.Controllers
{
    public class NewsStoriesController : ControllerBase
    {
        [ApiController]
        [Route("[controller]")]
        public class HackerNewsController : ControllerBase
        {
            [HttpGet]
            public async Task<ActionResult<IEnumerable<News>>> Get()
            {
                HttpClient client = new HttpClient();

                try
                {
                    //var url = "https://hacker-news.firebaseio.com/v0/newstories.json? \r\nprint=pretty&orderBy=\"$key\"&limitToFirst=1";

                    //var url2 = "https://hacker-news.firebaseio.com/v0/newstories.json? \r\nprint=pretty&orderBy=\"$key\"&limitToFirst=5";

                    //var url3 = "https://hacker-news.firebaseio.com/v0/item/8836.json? \r\nprint=pretty&orderBy=\"$key\"&limitToFirst=1";

                    var url4 = "https://hacker-news.firebaseio.com/v0/item/8836.json?print=pretty";

                    var response = client.GetAsync(url4).Result;

                    var responseValues = await response.Content.ReadAsStringAsync();

                    //foreach (var value in responseValues)
                    //{
                    //    Console.WriteLine(value);
                    //}

                    return Ok(responseValues);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occurred retrieving stories.", ex);
                }
            }
        }
    }
}
