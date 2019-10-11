using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGithubApi.Models
{
    public class Response
    {
        [JsonProperty("total_count")]
        public int ResultCount { get; set; }
        [JsonProperty("items")]
        public IEnumerable<Repository> Repo { get; set; }
    }
}
