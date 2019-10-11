using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGithubApi.Models
{
    public class Author
    {

        [JsonProperty("login")]
        public string AuthorLogin { get; set; }
        [JsonProperty("avatar_url")]
        public string AuthorAvatar { get; set; }

    }

}
