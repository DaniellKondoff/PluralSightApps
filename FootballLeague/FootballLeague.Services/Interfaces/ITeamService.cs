using FootballLeague.Services.Common;
using FootballLeague.Services.Models.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Services.Interfaces
{
    public interface ITeamService : IService
    {
        Task<IEnumerable<TeamListServiceModel>> All(int page);
        Task<int> TotalAsync();
    }
}
