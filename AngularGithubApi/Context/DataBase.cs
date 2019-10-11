using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularGithubApi.Models;
using AngularGithubApi.ViewModel;

namespace AngularGithubApi
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Requests> Strings { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
