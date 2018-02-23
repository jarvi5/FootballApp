using System;
using System.Collections.Generic;

namespace FootballApp.Data
{
    public class LeagueDetails
    {
        public string leagueCaption { get; set; }
        public int matchday { get; set; }
        public IList<Team> standing { get; set; }
    }
}
