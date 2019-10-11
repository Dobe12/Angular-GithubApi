using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AngularGithubApi.ViewModel;

namespace AngularGithubApi.Models
{
    public class Requests
    {       
        public string RequestString { get; set; }
        [Key]
        public DateTime Date { get; set; }
        public IEnumerable<Card> Cards { get; set; }

    }
}
