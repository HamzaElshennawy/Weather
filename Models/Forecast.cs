﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class Forecase
    {
        [JsonProperty("forecastday")]
        public Forecastday[] forecastday { get; set; }
    }
}