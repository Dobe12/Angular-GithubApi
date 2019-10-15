using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AngularGithubApi.ViewModel;

namespace AngularGithubApi.Models
{
    public class SearchedKeyWord
    {
        [Key]
        public string KeyWord { get; set; }       
        public DateTime Date { get; set; }
        public ICollection<RepositoryViewModel> Repositories { get; set; }

    }
}
