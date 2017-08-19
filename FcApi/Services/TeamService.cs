using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Net.Http;
using System.Net.Http.Headers;
using FcApi.ViewModels;

namespace FcApi.Services
{
    public class TeamService : Interfaces.ITeamService
    {
      
        public TeamService()
        {

        }

        public async Task<IEnumerable<ViewModels.Team>> GetTeamsAsync()
        {
            //const string url = "http://databaseproject.orgfree.com/fc/teamInfo.php";
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
            
            Console.Write(msg);
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
