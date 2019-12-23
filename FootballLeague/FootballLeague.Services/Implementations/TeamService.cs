using AutoMapper;
using AutoMapper.QueryableExtensions;
using FootballLeague.Data;
using FootballLeague.Services.Interfaces;
using FootballLeague.Services.Models.Teams;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FootballLeague.Services.Common.ServiceConstants;

namespace FootballLeague.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly FootballDbContext dbContext;
        private readonly IMapper mapper;

        public TeamService(FootballDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TeamListServiceModel>> All(int page = 1)
        {
            return await this.dbContext
                .Teams
                .Skip((page - 1) * TeamPageSize)
                .Take(TeamPageSize)
                .ProjectTo<TeamListServiceModel>(this.mapper.ConfigurationProvider)
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.GoalsScored)
                .ThenBy(t => t.GoalsAgainst)
                .ThenBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<int> TotalAsync()
        {
            return await this.dbContext
                .Teams
                .CountAsync();
        }
    }
}
