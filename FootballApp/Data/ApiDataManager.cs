using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FootballApp.Data
{
    public class ApiDataManager : IDataManager<string>
    {
        public string Data { get; set; }
        HttpClient HttpClient { get; set; }

        public ApiDataManager() {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public IEnumerable<League> GetAllLeagues()
        {
            return JsonConvert.DeserializeObject<IEnumerable<League>>(Data);
        }

        public IEnumerable<Team> GetLeagueTable()
        {
            var leagueDetails = JsonConvert.DeserializeObject<LeagueDetails>(Data);
            return leagueDetails.Standing;
        }

        public IEnumerable<Player> GetPlayers() 
        {
            var players = JsonConvert.DeserializeObject<Players>(Data);
            return players.PlayersList;
        }

        public IEnumerable<Fixture> GetFixtures()
        {
            var fixtures = JsonConvert.DeserializeObject<Fixtures>(Data);
            return fixtures.FixturesList;
        }

        public async Task LoadData(string source)
        {
            Data = await HttpClient.GetStringAsync(source);
        }
    }
}