using System;
using System.Collections.Generic;

namespace FootballApp.Data
{
    public class Team
    {
        public int position { get; set; }
        public string teamName { get; set; }
        public TeamLinks _links { get; set; }
        public int playedGames { get; set; }
        public string crestURI { get; set; }
        public int points { get; set; }
        public int goals { get; set; }
        public int goalsAgainst { get; set; }
        public int goalDifference { get; set; }
    }
}
