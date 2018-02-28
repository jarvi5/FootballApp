using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballApp.Data
{
    public interface IDataManager<T>
    {
        string Data { get; set; }

        Task LoadData(T source);
        IEnumerable<League> GetAllLeagues();
        IEnumerable<Team> GetLeagueTable();
        IEnumerable<Player> GetPlayers();
        IEnumerable<Fixture> GetFixtures();
    }
}
