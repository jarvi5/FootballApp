using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace FootballApp.Data
{
    public class DataManager
    {
        public HttpClient HttpClient { get; set; }
        const string Url = "http://www.football-data.org/v1/";
        private int season = DateTime.Now.Month > 7 ? DateTime.Now.Year : DateTime.Now.Year - 1;

        public DataManager() {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<League>> GetAllLeagues()
        {
            string result = await HttpClient.GetStringAsync(Url + "competitions/?season=" + season);
            return JsonConvert.DeserializeObject<IEnumerable<League>>(result);
        }

        public async Task<IEnumerable<Team>> GetLeagueTable(int id)
        {
            string result = await HttpClient.GetStringAsync(Url + "competitions/" + id + "/leagueTable");
            var leagueDetails = JsonConvert.DeserializeObject<LeagueDetails>(result);
            return leagueDetails.Standing;
        }

        public async Task<IEnumerable<Player>> GetPlayers(string url) 
        {
            string result = await HttpClient.GetStringAsync(url + "/players");
            var players = JsonConvert.DeserializeObject<Players>(result);
            return players.PlayersList;
        }

        public async Task<IEnumerable<Fixture>> GetFixtures(string url)
        {
            string result = await HttpClient.GetStringAsync(url + "/fixtures");
            var fixtures = JsonConvert.DeserializeObject<Fixtures>(result);
            return fixtures.FixturesList;
        }
    }
}