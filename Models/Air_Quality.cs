using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("air_quality")]
    public class Air_Quality
    {
        [JsonProperty("co")]
        public float co { get; set; }

        [JsonProperty("no2")]
        public float no2 { get; set; }

        [JsonProperty("o3")]
        public float o3 { get; set; }

        [JsonProperty("so2")]
        public float so2 { get; set; }

        [JsonProperty("pm2_5")]
        public float pm2_5 { get; set; }

        [JsonProperty("pm10")]
        public float pm10 { get; set; }

        [JsonProperty("us-epa-index")]
        public int usepaindex { get; set; }

        [JsonProperty("gb-defra-index")]
        public int gbdefraindex { get; set; }
    }
}
