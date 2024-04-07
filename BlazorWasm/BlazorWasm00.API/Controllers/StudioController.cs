using BlazorWasm40.Application.Repository.EntityRepository;
using BlazorWasm60.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWasm00.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private ILogger<StudioController> _logger;
        private IRepositoryStudio _repositoryStudio;

        public StudioController(ILogger<StudioController> logger, IRepositoryStudio repositoryStudio)
        {
            _logger = logger;
            _repositoryStudio = repositoryStudio;
        }

        // GET: api/<StudioController>
        [HttpGet]
        public IEnumerable<Studio> Get()
        {
            IEnumerable<Studio> val = _repositoryStudio.GetAll();
            return val;
        }

        // GET api/<StudioController>/5
        [HttpGet("{id}")]
        public Studio Get(int id)
        {
            return _repositoryStudio.GetById(id);
        }

        // PUT api/<StudioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Studio value)
        {
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
