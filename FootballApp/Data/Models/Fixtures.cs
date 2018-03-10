using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FootballApp.Data
{
    public class Fixtures
    {
        [JsonProperty("fixtures")]
        public IList<Fixture> FixturesList { get; set; }
    }

    public class Fixture
    {
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public int? GoalsHomeTeam { get; set; }
        public int? GoalsAwayTeam { get; set; }
    }
}
