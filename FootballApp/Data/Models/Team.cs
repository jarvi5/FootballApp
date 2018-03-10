using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FootballApp.Data
{
    public class Team
    {
        public int? Position { get; set; }
        public string TeamName { get; set; }
        [JsonProperty("_links")]
        public TeamLinks Links { get; set; }
        public int? PlayedGames { get; set; }
        public string CrestURI { get; set; }
        public int? Points { get; set; }
        public int? Goals { get; set; }
        public int? GoalsAgainst { get; set; }
        public int? GoalDifference { get; set; }
        public string Group { get; set; }
    }

    public class TeamLinks
    {
        public Link Team { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
    }

    public class TeamConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Team));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonTeam = JObject.Load(reader);
            var team = new Team();

            team.Position = jsonTeam["position"]?.ToObject<int?>();
            team.TeamName = (string)jsonTeam["team"];
            team.Links = new TeamLinks();
            team.Links.Team = new Link();
            team.Links.Team.Href = "http://api.football-data.org/v1/teams/" + jsonTeam["teamId"];
            team.PlayedGames = jsonTeam["playedGames"]?.ToObject<int?>();
            team.CrestURI = (string)jsonTeam["crestURI"];
            team.Points = jsonTeam["points"]?.ToObject<int?>();
            team.Goals = jsonTeam["goals"]?.ToObject<int?>();
            team.GoalsAgainst = jsonTeam["goalsAngaist"]?.ToObject<int?>();
            team.GoalDifference = jsonTeam["goalDifference"]?.ToObject<int?>();
            team.Group = (string)jsonTeam["group"];


            return team;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
