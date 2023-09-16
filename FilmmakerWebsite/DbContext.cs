using FilmmakerWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmmakerWebsite
{
    public class FilmmakingDbContext : DbContext
    {
        public FilmmakingDbContext(DbContextOptions<FilmmakingDbContext> options) : base(options) { }

        // Define DbSet properties for your models (e.g., Script and Technique).
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Technique> Techniques { get; set; }
    }
}

