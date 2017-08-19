using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FcApi.ViewModels;

namespace FcApi.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<IEnumerable<TeamLocation>> GetTeamLocations(int teamId = 0);
    }
}
