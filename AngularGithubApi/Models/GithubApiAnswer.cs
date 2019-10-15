using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGithubApi.Models
{
    public class GithubApiAnswer
    {
        [JsonProperty("total_count")]
        public int ResultCount { get; set; }
        [JsonProperty("items")]
        public ICollection<Repository> Repositories { get; set; }
    }
}
