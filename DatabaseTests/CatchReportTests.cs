using FiskeNettet;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseTests
{
    public class CatchReportTests
    {
        private readonly HttpClient _client;

        public CatchReportTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task TestGetAllCatchReport()
        {
            //ARRANGE
            var request = "api/CatchReport";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.GetAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task TestGetSingleCatchReport()
        {
            //ARRANGE
            var request = "api/CatchReport/608fa4c94d7a28268733aab0";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.GetAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task TestRemoveCatchReport()
        {
            //ARRANGE

            var request = "api/CatchReport/60ae3ff31d418bca0b8f975e";

            //ACT
            //Check if httpResponse is 200 / OK
            var response = await _client.DeleteAsync(request);

            //ASSERT
            response.EnsureSuccessStatusCode();

        }


    }
}