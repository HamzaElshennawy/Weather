using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("location")]
    public class Location
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("lat")]
        public float lat { get; set; }

        [JsonProperty("lon")]
        public float lon { get; set; }

        [JsonProperty("tz_id")]
        public string tz_id { get; set; }

        [JsonProperty("localtime_epoch")]
        public int localtime_epoch { get; set; }

        [JsonProperty("localtime")]
        public string localtime { get; set; }
    }
}
