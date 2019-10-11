using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularGithubApi.Models;
using AngularGithubApi.ViewModel;

namespace AngularGithubApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<JObject, Card>()
                .ForMember(x => x.Name, y => y.MapFrom(j => j.SelectToken(".items.name")))
                .ForMember(x => x.AuthorLogin, y => y.MapFrom(j => j.SelectToken(".items.owner.login")))
                .ForMember(x => x.AuthorAvatar, y => y.MapFrom(j => j.SelectToken(".items.owner.avatar_url")))
                .ForMember(x => x.Link, y => y.MapFrom(j => j.SelectToken(".items.url")))
                .ForMember(x => x.Language, y => y.MapFrom(j => j.SelectToken(".items.language")))
                .ForMember(x => x.StarCount, y => y.MapFrom(j => j.SelectToken(".items.stargazers_count")))
                .ForMember(x => x.ForkCount, y => y.MapFrom(j => j.SelectToken(".items.forks_count")));
        }
    }
}
