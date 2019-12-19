using FootballLeague.Data;
using FootballLeague.Services.Interfaces;
using FootballLeague.Services.Models.Teams;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private const int TeamPageSize = 10;

        private readonly FootballDbContext dbContext;

        public TeamService(FootballDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamList>> All(int page)
        {
            return await this.dbContext
                .Teams
                .Skip((page - 1) * TeamPageSize)
                .Take(TeamPageSize)
                .Select(t => new TeamList
                {
                    Name = t.Name,
                    Natioality = t.Nationality
                })
                .ToListAsync();
        }
    }
}
