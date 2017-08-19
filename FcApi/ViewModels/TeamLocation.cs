using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FcApi.ViewModels
{
    public class TeamLocation
    {   
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string CityState { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
