using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Ok("OK");
        }
    }
}
