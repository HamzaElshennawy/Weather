using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("current")]
    public class Current
    {
        [JsonProperty("last_updated_epoch")]
        public int last_updated_epoch { get; set; }

        [JsonProperty("last_updated")]
        public string last_updated { get; set; }

        [JsonProperty("temp_c")]
        public float temp_c { get; set; }

        [JsonProperty("temp_f")]
        public float temp_f { get; set; }

        [JsonProperty("is_day")]
        public int is_day { get; set; }

        [JsonProperty("condition")]
        public Condition condition { get; set; }

        [JsonProperty("wind_mph")]
        public float wind_mph { get; set; }

        [JsonProperty("wind_kph")]
        public float wind_kph { get; set; }

        [JsonProperty("wind_degree")]
        public int wind_degree { get; set; }

        [JsonProperty("wind_dir")]
        public string wind_dir { get; set; }

        [JsonProperty("pressure_mb")]
        public float pressure_mb { get; set; }

        [JsonProperty("pressure_in")]
        public float pressure_in { get; set; }

        [JsonProperty("precip_mm")]
        public float precip_mm { get; set; }

        [JsonProperty("precip_in")]
        public float precip_in { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("cloud")]
        public int cloud { get; set; }

        [JsonProperty("feelslike_c")]
        public float feelslike_c { get; set; }

        [JsonProperty("feelslike_f")]
        public float feelslike_f { get; set; }

        [JsonProperty("vis_km")]
        public float vis_km { get; set; }

        [JsonProperty("vis_miles")]
        public float vis_miles { get; set; }

        [JsonProperty("uv")]
        public float uv { get; set; }

        [JsonProperty("gust_mph")]
        public float gust_mph { get; set; }

        [JsonProperty("gust_kph")]
        public float gust_kph { get; set; }
    }
}
