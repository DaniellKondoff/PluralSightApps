using FootballLeague.Services.Models.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamList>> All(int page);
    }
}
