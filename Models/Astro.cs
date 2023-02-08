using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("astro")]
    public class Astro
    {
        [JsonProperty("sunrise")]
        public string sunrise { get; set; }

        [JsonProperty("sunset")]
        public string sunset { get; set; }

        [JsonProperty("moonrise")]
        public string moonrise { get; set; }

        [JsonProperty("moonset")]
        public string moonset { get; set; }

        [JsonProperty("moon_phase")]
        public string moon_phase { get; set; }

        [JsonProperty("moon_illumination")]
        public string moon_illumination { get; set; }

        [JsonProperty("is_moon_up")]
        public int is_moon_up { get; set; }

        [JsonProperty("is_sun_up")]
        public int is_sun_up { get; set; }
    }
}
