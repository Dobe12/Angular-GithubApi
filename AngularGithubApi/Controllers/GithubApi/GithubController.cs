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

namespace AngularGithubApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly GithubApiHandler _githubApiHandler;
        private readonly DataBaseContext _dataBaseContext;

        public GithubController(GithubApiHandler githubApiHandler, DataBaseContext dataBaseContext)
        {
            _githubApiHandler = githubApiHandler;
            _dataBaseContext = dataBaseContext;
        }

        // GET: api/Github
        [HttpGet]
        public  ActionResult Get()
        {
            Requests lastRequest = _dataBaseContext.Strings.Include(s => s.Cards).OrderByDescending(d => d.Date).FirstOrDefault();

            if (lastRequest == null)
            {
                return NotFound("No search yet");
            }

            return Ok(lastRequest.Cards);
        }

        // GET: api/Github/5
        [HttpGet("search/{request}")]
        public async Task<ActionResult<List<Card>>>  Search(string request)
        {
            Response response = await _githubApiHandler.GedDataFromRequest(request);
            List<Card> cards = _githubApiHandler.AddToViewModel(response);

            _dataBaseContext.Add(new Requests { RequestString = request, Date = DateTime.Now, Cards = cards }) ;
            _dataBaseContext.SaveChanges();

            return Ok(cards);
        }

    }
}
