using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FcApi.ViewModels
{
    public class Team
    {   
        [JsonProperty("id")]
        public string TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("sport_type")]
        public string SportType { get; set; }

        [JsonProperty("Conference")]
        public string Conference { get; set; }

        [JsonProperty("Division")]
        public string Division { get; set; }

        [JsonProperty("city_state")]
        public string CityState { get; set; }

        [JsonProperty("Lat")]
        public string Latitude { get; set; }

        [JsonProperty("Long")]
        public string Longitude { get; set; }
    }
}
