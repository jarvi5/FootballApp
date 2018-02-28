using System;
using System.Collections.Generic;

namespace FootballApp.Data
{
    public class LeagueDetails
    {
        public string LeagueCaption { get; set; }
        public int? Matchday { get; set; }
        public IList<Team> Standing { get; set; }
    }
}
