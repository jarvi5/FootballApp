using System;
using System.Net.Http;
using FootballApp.Data;
using Xunit;

namespace FootballApp.Tests
{
    public class DataManagerTests
    {
        DataManager Manager;

        [Fact]
        public void HttpClientHasCorrectHeaders()
        {
            Manager = new DataManager();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            Assert.Equal(client.DefaultRequestHeaders.ToString(), Manager.HttpClient.DefaultRequestHeaders.ToString()) ;
        }

    }
}
