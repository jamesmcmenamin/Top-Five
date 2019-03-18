using System.Collections.Generic;
using Newtonsoft.Json;

namespace TopGit.Models
{
    public class Repository
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}