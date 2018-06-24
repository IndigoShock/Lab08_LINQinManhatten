using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_LINQinManhatten
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}
