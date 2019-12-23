using System.Collections.Generic;

namespace FootballLeague.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losts { get; set; }
        public int Points { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
