using BlazorWasm40.Application.Repository.EntityRepository;
using BlazorWasm60.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWasm00.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private ILogger<VideoGameController> _logger;
        private IRepositoryVideoGame _repositoryVideoGame;

        public VideoGameController(ILogger<VideoGameController> logger, IRepositoryVideoGame repositoryVideoGame)
        {
            _logger = logger;
            _repositoryVideoGame = repositoryVideoGame;
        }

        // GET: api/<VideoGameController>
        [HttpGet]
        public async Task<IEnumerable<VideoGame>> Get()
        {
            IEnumerable<VideoGame> val = await _repositoryVideoGame.GetAll();
            return val;
        }

        // GET api/<VideoGameController>/5
        [HttpGet("{id}")]
        public async Task<VideoGame> Get(int id)
        {
            return await _repositoryVideoGame.GetById(id);
        }

        // PUT api/<VideoGameController>/5
        [HttpPut]
        public async Task Put([FromBody] VideoGame value)
        {
            await _repositoryVideoGame.Add(value);
            await _repositoryVideoGame.Save();
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VideoGame value)
        {
            await _repositoryVideoGame.Update(value);
            await _repositoryVideoGame.Save();
        }

        // DELETE api/<VideoGameController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }


    }
}
