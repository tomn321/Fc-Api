using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FcApi.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<ViewModels.Team>> GetTeamsAsync();
    }
}
