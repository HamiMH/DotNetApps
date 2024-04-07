using BlazorWasm40.Application.Repository.EntityRepository;
using BlazorWasm60.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm20.InfrastructureCfDb.Repository.EntityRepository
{
    internal class RepositoryVideoGame : RepositoryBase<VideoGame>, IRepositoryVideoGame
    {
        public RepositoryVideoGame(GamesDbContext gamesDbContext) : base(gamesDbContext)
        {
        }
    }
}
