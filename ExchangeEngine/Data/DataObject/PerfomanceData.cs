using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangeEngine.Data.DataObject
{
    public class PerfomanceData
    {
        [JsonProperty("Meta Data")]
        public Metadata Metadata { get; set; }

        public List<TimeSeries> TimeSeries { get; set; }
    }
}