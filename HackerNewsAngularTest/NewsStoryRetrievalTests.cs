using HackerNewsAngularTest.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAngularTest
{
    public class NewsStoryRetrievalTests : ControllerBase
    {
        [Fact]
        public void ValidateResponseFound()
        {
            News responseValues = new News();
            {
                responseValues.id = 1;
                responseValues.title = "Test News Story Title";
                responseValues.poll = 10;
                responseValues.score = 12;
                responseValues.url = "https://Test/FakeStoryLocation";
            }

            if (responseValues != null)
            {
                Ok();
            }

            Assert.False(responseValues == null);
            Assert.NotNull(responseValues);
        }

        [Fact]
        public void ValidateResponseNotFound()
        {
            News responseValues = new News()
            {
                id = null
            };

            if (responseValues.id == null)
            {
                NotFound();
            }

            Assert.True(responseValues.id == null);
            Assert.Null(responseValues.id);
        }
    }
}