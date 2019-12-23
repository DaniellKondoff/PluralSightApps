using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Infrastructure
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions AddAutoValidateAntiforgeryToken(this MvcOptions options)
        {
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            return options;
        }
    }
}
