using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Restaurants_API.Controllers.Tests
{
    public class RestaurantsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public RestaurantsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact] 
        public async Task GetAll_forValidRequest_Return200k()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/api/restaurant?pageNumber=1&pageSize=10");

            // Assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
