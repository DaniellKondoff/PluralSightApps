using AutoMapper;
using FootballLeague.Data.Models;
using FootballLeague.Services.Models.Teams;

namespace FootballLeague.Services.Infrastrucutre
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Team, TeamListServiceModel>();
        }
    }
}
