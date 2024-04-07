using BlazorWasm40.Application.Repository.EntityRepository;
using BlazorWasm40.Application.Utils;
using BlazorWasm60.Domain;
using BlazorWasm60.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasm00.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;
        private IRepositoryDeveloper _repositoryDeveloper;
        private IIteratorFormating _iteratorFormating;

        public DeveloperController(ILogger<DeveloperController> logger, IRepositoryDeveloper repositoryDeveloper, IIteratorFormating iteratorFormating )
        {
            _logger = logger;
            _repositoryDeveloper = repositoryDeveloper;
            _iteratorFormating = iteratorFormating;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Developer> Get()
        {
            List< Developer > val= _repositoryDeveloper.GetAll().ToList();
            string a= _iteratorFormating.ExportIteratorToString(val);
            return val;
        }

        [HttpGet("{id}")]
        public Developer GetById(int id)
        {
            return _repositoryDeveloper.GetById(id);
        }

        // PUT api/<StudioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Developer value)
        {
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
