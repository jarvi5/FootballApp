using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballApp.Data
{
    public interface IDataManager
    {
        Task<Response<IEnumerable<League>>> GetAllLeagues();
        Task<Response<IEnumerable<Team>>> GetLeagueTable(League league);
        Task<Response<IEnumerable<Player>>> GetPlayers(Team team);
        Task<Response<IEnumerable<Fixture>>> GetFixtures(Team team);
    }
}
