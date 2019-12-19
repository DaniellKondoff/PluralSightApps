using FootballLeague.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data
{
    public class FootballDbContext : IdentityDbContext<User>
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

    }
}
