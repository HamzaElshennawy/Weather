using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [JsonObject("condition")]
    public class Condition
    {
        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        [JsonProperty("code")]
        public int code { get; set; }
    }

}
