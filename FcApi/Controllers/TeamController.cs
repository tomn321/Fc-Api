using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using FcApi.ViewModels;

namespace FcApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Team")]
    public class TeamController : Controller
    {

        private readonly Services.Interfaces.ITeamService _teamService;

        public TeamController(Services.Interfaces.ITeamService teamService)
        {
            _teamService = teamService;
        }


        // GET: api/Team
        [HttpGet]
        [Route("TeamLocation/{teamId}")]
        public async Task<IEnumerable<TeamLocation>> GetTeamLocations([FromBody]int teamId)
        {
            return await _teamService.GetTeamLocations(teamId);
        }

        [HttpGet]
        [Route("TeamInfo")]
        public async Task<IEnumerable<Team>> GetTeamInfo()
        {
            return await _teamService.GetTeamsAsync();
        }

        //// GET: api/Team/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        //// POST: api/Team
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        //// PUT: api/Team/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
