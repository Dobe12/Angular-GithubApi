using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularGithubApi.Models;
using AngularGithubApi.ViewModel;

namespace AngularGithubApi
{
    public class RepositoryContext : DbContext
    {
        public DbSet<SearchedKeyWord> SearchedKeyWord { get; set; }
        public DbSet<RepositoryViewModel> Repository { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
