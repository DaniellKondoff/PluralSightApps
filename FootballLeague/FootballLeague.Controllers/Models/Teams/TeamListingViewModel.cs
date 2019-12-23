using FootballLeague.Services.Common;
using FootballLeague.Services.Models.Teams;
using System;
using System.Collections.Generic;

namespace FootballLeague.Controllers.Models.Teams
{
    public class TeamListingViewModel
    {
        public IEnumerable<TeamListServiceModel> Teams { get; set; }

        public int TotalTeams { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalTeams / ServiceConstants.TeamPageSize);

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
