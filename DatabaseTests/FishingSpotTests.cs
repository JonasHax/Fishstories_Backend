using FiskeNettet;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseTests
{
    public class FishingSpotTests
    {
        private readonly HttpClient _client;

        public FishingSpotTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task TestGetAllFishingSpots()
        {
            //ARRANGE
            var request = "api/FishingSpot";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.GetAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task TestGetSingleFishingSpot()
        {
            //ARRANGE
            var request = "api/FishingSpot/608144485aebf284fc3553f2";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.GetAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task TestRemoveFishingSpot()
        {
            //ARRANGE

            var request = "api/FishingSpot/60ae3ff31d418bca0b8f975e";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.DeleteAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }
    }
}
