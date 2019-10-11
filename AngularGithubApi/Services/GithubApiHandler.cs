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

namespace AngularGithubApi.Services
{
    public class GithubApiHandler
    {
        private readonly string _gitApiRequestString = "https://api.github.com/search/repositories?q=";
        private readonly string _gitApiRequestOptionsString = "&sort=updated&order=desc";
        private readonly string _userAgent = "Mock";
        private IMapper _mapper;

        public GithubApiHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response> GedDataFromRequest(string request)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", _userAgent);

            string uri = _gitApiRequestString + request + _gitApiRequestOptionsString;
            
            string content = await client.GetStringAsync(uri);
            var json = JObject.Parse(content).ToString();
            //List<Card> card = _mapper.Map<List<Card>>(json);

            Response objectsFromResponse = JsonConvert.DeserializeObject<Response>(json);

            return objectsFromResponse;
        }

        public List<Card> AddToViewModel(Response objects)
        {
            var cards = new List<Card>();
            int count = 0;

            foreach (var card in objects.Repo)
            {
                if (count > 10)
                {
                    break;
                }
                else
                {
                    cards.Add(new Card
                    {
                        AuthorAvatar = card.Author.AuthorAvatar,
                        AuthorLogin = card.Author.AuthorLogin,
                        ForkCount = card.ForkCount,
                        StarCount = card.StarCount,
                        Language = card.Language,
                        Link = card.Link,
                        Name = card.Name,
                        LastUpdate = card.LastUpdate,
                        Description = card.Description
                    });
                    count++;
                }
            }
            return cards;
        }
    }
}
