namespace FootballLeague.Services.Models.Teams
{
    public class TeamListServiceModel
    {
        public string Name { get; set; }
        public string Natioality { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losts { get; set; }
        public int Points { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
    }
}
