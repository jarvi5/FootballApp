using System.Collections.Generic;
using Newtonsoft.Json;

namespace FootballApp.Data
{
    public class Players
    {
        [JsonProperty("players")]
        public IList<Player> PlayersList { get; set; }
    }
}
