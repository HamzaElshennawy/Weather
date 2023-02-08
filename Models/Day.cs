using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("day")]
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public float maxtemp_c { get; set; }

        [JsonProperty("maxtemp_f")]
        public float maxtemp_f { get; set; }

        [JsonProperty("mintemp_c")]
        public float mintemp_c { get; set; }

        [JsonProperty("mintemp_f")]
        public float mintemp_f { get; set; }

        [JsonProperty("avgtemp_c")]
        public float avgtemp_c { get; set; }

        [JsonProperty("avgtemp_f")]
        public float avgtemp_f { get; set; }

        [JsonProperty("maxwind_mph")]
        public float maxwind_mph { get; set; }

        [JsonProperty("maxwind_kph")]
        public float maxwind_kph { get; set; }

        [JsonProperty("totalprecip_mm")]
        public float totalprecip_mm { get; set; }

        [JsonProperty("totalprecip_in")]
        public float totalprecip_in { get; set; }

        [JsonProperty("avgvis_km")]
        public float totalsnow_cm { get; set; }

        [JsonProperty("avgvis_miles")]
        public float avgvis_km { get; set; }

        [JsonProperty("avgvis_miles")]
        public float avgvis_miles { get; set; }

        [JsonProperty("avghumidity")]
        public float avghumidity { get; set; }

        [JsonProperty("daily_will_it_rain")]
        public int daily_will_it_rain { get; set; }

        [JsonProperty("daily_chance_of_rain")]
        public int daily_chance_of_rain { get; set; }

        [JsonProperty("daily_will_it_snow")]
        public int daily_will_it_snow { get; set; }

        [JsonProperty("daily_chance_of_snow")]
        public int daily_chance_of_snow { get; set; }

        [JsonProperty("condition")]
        public Condition condition { get; set; }

        [JsonProperty("uv")]
        public float uv { get; set; }
    }
}
