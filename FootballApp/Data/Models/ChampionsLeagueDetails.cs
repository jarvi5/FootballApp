using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballApp.Data
{
    public class ChampionsLeagueDetails
    {
        public string LeagueCaption { get; set; }
        public int? Matchday { get; set; }
        public ChampionsLeagueGroups Standings { get; set; }
    }

    public class ChampionsLeagueGroups
    {
        public IList<Team> A { get; set; }
        public IList<Team> B { get; set; }
        public IList<Team> C { get; set; }
        public IList<Team> D { get; set; }
        public IList<Team> E { get; set; }
        public IList<Team> F { get; set; }
        public IList<Team> G { get; set; }
        public IList<Team> H { get; set; }

        public IList<Team> GetTeams()
        {
            return A.Concat(B)
                    .Concat(C)
                    .Concat(D)
                    .Concat(E)
                    .Concat(F)
                    .Concat(G)
                    .Concat(H)
                    .ToList();
        }
    }
}
