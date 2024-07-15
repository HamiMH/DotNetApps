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
        public async  Task<IEnumerable<Developer>> Get()
        {
            IEnumerable< Developer > val=await _repositoryDeveloper.GetAll();
            string a= _iteratorFormating.ExportIteratorToString(val);
            return val;
        }

        [HttpGet("{id}")]
        public async Task<Developer> GetById(int id)
        {
            return await _repositoryDeveloper.GetById(id);
        }

		[HttpPut]
		public async Task Put([FromBody] Developer value)
		{
			await _repositoryDeveloper.Add(value);
			await _repositoryDeveloper.Save();
		}

		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] Developer value)
		{
			await _repositoryDeveloper.Update(value);
			await _repositoryDeveloper.Save();
		}

		// DELETE api/<StudioController>/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
