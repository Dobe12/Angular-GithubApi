using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGithubApi.Models
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("html_url")]
        public string Link { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("stargazers_count")]
        public int StarCount { get; set; }
        [JsonProperty("forks_count")]
        public int ForkCount { get; set; }
        [JsonProperty("owner")]
        public Author Author { get; set; }
        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
