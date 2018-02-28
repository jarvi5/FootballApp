using System;
using Newtonsoft.Json;

namespace FootballApp.Data
{
    public class League
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        [JsonProperty("league")]
        public string Name { get; set; }
        public string Year { get; set; }
        public int? NumberOfTeams { get; set; }
        public int? NumberOfGames { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
