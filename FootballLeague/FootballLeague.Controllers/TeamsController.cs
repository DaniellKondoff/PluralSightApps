using FootballLeague.Controllers.Models.Teams;
using FootballLeague.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;
        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int page = 1)
        {
            var allTeams = await this.teamService.All(page);

            return View(new TeamListingViewModel
            {
                Teams = allTeams,
                CurrentPage = page,
                TotalTeams = await teamService.TotalAsync()
            }) ;
        }
    }
}
