using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using FootballApp.Helpers;

namespace FootballApp.Data
{
    public class ApiDataManager : IDataManager
    {
        HttpClient HttpClient { get; set; }
        const string BaseUrl = "http://www.football-data.org/v1/";
        int Season = DateTime.Now.Month > 7 ? DateTime.Now.Year : DateTime.Now.Year - 1;

        public ApiDataManager()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<Response<IEnumerable<League>>> GetAllLeagues()
        {
            Response<IEnumerable<League>> response = new Response<IEnumerable<League>>();
            try 
            {
                response.Data = await GetData<IEnumerable<League>>(BaseUrl + "competitions/?season=" + Season);
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "leagues not found";
            }
            return response;
        }

        public async Task<Response<IEnumerable<Team>>> GetLeagueTable(League league)
        {
            Response<IEnumerable<Team>> response = new Response<IEnumerable<Team>>();
            try
            {
                LeagueDetails leagueDetails = await GetData<LeagueDetails>(BaseUrl + "competitions/" + league.Id + "/leagueTable");
                response.Data = leagueDetails.Standing;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "Teams not found";
            }
            return response;
        }

        public async Task<Response<IEnumerable<Player>>> GetPlayers(Team team)
        {
            Response<IEnumerable<Player>> response = new Response<IEnumerable<Player>>();
            try
            {
                Players players = await GetData<Players>(team.Links.Team.Href + "/players");
                response.Data = players.PlayersList;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "Players not found";
            }
            return response;
        }

        public async Task<Response<IEnumerable<Fixture>>> GetFixtures(Team team)
        {
            Response<IEnumerable<Fixture>> response = new Response<IEnumerable<Fixture>>();
            try
            {
                Fixtures fixtures = await GetData<Fixtures>(team.Links.Team.Href + "/fixtures");
                response.Data = fixtures.FixturesList;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "Fixtures not found";
            }
            return response;
        }

        async Task<T> GetData<T>(string url)
        {
            string result = await HttpClient.GetStringAsync(url);
            return Serialization<T>.Deserialize(result);
        }
    }
}