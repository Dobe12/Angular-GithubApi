using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGithubApi.ViewModel
{
    public class RepositoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorLogin { get; set; }
        public string AuthorAvatar { get; set; }
        public string Link { get; set; }
        public string Language { get; set; }
        public int StarCount { get; set; }
        public int ForkCount { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Description { get; set; }
    }

}
