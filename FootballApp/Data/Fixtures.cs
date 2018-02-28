using System.Collections.Generic;
using Newtonsoft.Json;

namespace FootballApp.Data
{
    public class Fixtures
    {
        [JsonProperty("fixtures")]
        public IList<Fixture> FixturesList { get; set; }
    }
}
