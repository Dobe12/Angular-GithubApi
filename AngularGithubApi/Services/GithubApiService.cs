using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngularGithubApi.Models;
using AngularGithubApi.ViewModel;
using Microsoft.Extensions.Options;
using System.Net.Http.Formatting;
using System.IO;

namespace AngularGithubApi.Services
{
    public class GithubApiService
    {
        private readonly ApplicationSettings _appSettings;

        public GithubApiService(IMapper mapper, IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<ICollection<Repository>> GetGithubApiAnser(string keyWord)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", _appSettings.UserAgent);

            string  uri = _appSettings.Uri + keyWord + _appSettings.UriProperties;

            string content = await client.GetStringAsync(uri);

            var githubApiAnswer = JsonConvert.DeserializeObject<GithubApiAnswer>(content);

            return githubApiAnswer.Repositories;
        }

       
    }
}
