using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AngularGithubApi.Models;
using AngularGithubApi.Services;
using AngularGithubApi.ViewModel;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace AngularGithubApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly GithubApiService _githubApiHandler;
        private readonly RepositoryContext _repositoryContext;
        private readonly ApplicationSettings _appSettings;
        private IMapper _mapper;

        public GithubController(GithubApiService githubApiHandler, RepositoryContext repositoryContext, IOptions<ApplicationSettings> appSettings, IMapper mapper)
        {
            _githubApiHandler = githubApiHandler;
            _repositoryContext = repositoryContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;

        }

        // GET: api/Github
        [HttpGet]
        public  ActionResult GetSearchedRepositories()
        {
            SearchedKeyWord searchedKeyWord = _repositoryContext.SearchedKeyWord.Include(fr => fr.Repositories).OrderByDescending(d => d.Date).FirstOrDefault();

            if (searchedKeyWord == null)
            {
                return NotFound("No search yet");
            }

            return Ok(searchedKeyWord.Repositories);
        }

        // GET: api/Github/5
        [HttpGet("search/{keyWord}")]
        public async Task<IActionResult>  Search(string keyWord)
        {
            ICollection<RepositoryViewModel> repositories = await _githubApiHandler.GetRepositories(keyWord);
            repositories = repositories.Take(10).ToArray();


            var searchedKeyWord = await _repositoryContext.SearchedKeyWord.FindAsync(keyWord);
            if (searchedKeyWord == null)
            {
                searchedKeyWord = new SearchedKeyWord() { KeyWord = keyWord, Repositories = repositories, Date = DateTime.Now };
                _repositoryContext.SearchedKeyWord.Add(searchedKeyWord);
            }
            else
            {
                searchedKeyWord.Repositories = repositories;
                _repositoryContext.Update(searchedKeyWord);
            }

            await _repositoryContext.SaveChangesAsync();

            return Ok(repositories);
        }

    }
}
