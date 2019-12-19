using FootballLeague.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;
        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public async Task<IActionResult> All()
        {
            return this.Ok();
        }
    }
}
