using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FootballApp.Data
{
    public class Players
    {
        [JsonProperty("players")]
        public IList<Player> PlayersList { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int? JerseyNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public DateTime? ContractUntil { get; set; }
    }
}
