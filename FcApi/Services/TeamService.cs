using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Net.Http;
using System.Net.Http.Headers;
using FcApi.ViewModels;
using System.Linq;

namespace FcApi.Services
{
    public class TeamService : Interfaces.ITeamService
    {
        //var urlTeamInfo = new Uri("http://databaseproject.orgfree.com/fc/teamInfo.php");
      
        public TeamService()
        {

        }

        public async Task<IEnumerable<TeamLocation>> GetTeamLocations(int teamId = 0)
        {
            var teamsLocations = await GetTeamsAsync();
            if(!teamsLocations.Any())return new List<TeamLocation>();

            var locations = new List<TeamLocation>();
            if(teamId == 0){

                foreach(var team in teamsLocations){

                locations.Add(new TeamLocation{
                    TeamId = Convert.ToInt32(team.TeamId),
                    TeamName = team.TeamName,
                    CityState = team.CityState,
                    Latitude = team.Latitude,
                    Longitude = team.Longitude
                    });
                }
            }
            else
            {
                var team = teamsLocations.FirstOrDefault(t => t.TeamId == teamId.ToString());
                locations.Add(new TeamLocation{
                    TeamId = Convert.ToInt32(team.TeamId),
                    TeamName = team.TeamName,
                    CityState = team.CityState,
                    Latitude = team.Latitude,
                    Longitude = team.Longitude
                    });
            }
            
            return locations;
               
        }
        
        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            
            IEnumerable<Team> teamInfo;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync("http://databaseproject.orgfree.com/fc/teamInfo.php");

            var msg = await stringTask;
            try
            {
                teamInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Team>>(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return teamInfo;

        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TeamServiceExtensions
    {
        public static IApplicationBuilder UseTeamService(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TeamService>();
        }
    }
}
