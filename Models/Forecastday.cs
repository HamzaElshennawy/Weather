using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("forecastday")]
    public class Forecastday
    {
        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("date_epoch")]
        public int date_epoch { get; set; }

        [JsonProperty("day")]
        public Day day { get; set; }

        [JsonProperty("astro")]
        public Astro astro { get; set; }

        [JsonProperty("hour")]
        public Hour[] hour { get; set; }
    }

}
