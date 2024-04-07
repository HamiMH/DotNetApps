using BlazorWasm60.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm20.InfrastructureCfDb.Repository
{
    internal class GamesDbContext : DbContext
    {
            public DbSet<Developer> Developers { get; set; }
            public DbSet<Studio> Studios { get; set; }
            public DbSet<VideoGame> VideoGames { get; set; }

            public string ConnString { get; }

            public GamesDbContext()
            {
            ConnString = "Server = DESKTOP-VVIHM3L\\SQLEXPRESS,1433; Database = GamesCodeFirst;User Id=blazorwasm;Password=a$$word;Trusted_Connection=True;Encrypt=false;";
            }

            // The following configures EF to create a Sqlite database file in the
            // special "local" folder for your platform.
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlServer($"{ConnString}");
    }
}
