using Newtonsoft.Json;

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
    }
}
