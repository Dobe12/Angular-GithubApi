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

            CreateMap<Repository, RepositoryViewModel>()
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.AuthorLogin, s => s.MapFrom(x => x.Author.AuthorLogin))
                .ForMember(x => x.AuthorAvatar, s => s.MapFrom(x => x.Author.AuthorAvatar))
                .ForMember(x => x.Link, s => s.MapFrom(x => x.Link))
                .ForMember(x => x.Language, s => s.MapFrom(x => x.Language))
                .ForMember(x => x.StarCount, s => s.MapFrom(x => x.StarCount))
                .ForMember(x => x.ForkCount, s => s.MapFrom(x => x.ForkCount))
                .ForMember(x => x.LastUpdate, s => s.MapFrom(x => x.LastUpdate))
                .ForMember(x => x.Description, s => s.MapFrom(x => x.Description));
        }
    }
}
