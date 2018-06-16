using System.Collections.Generic;
using System.Web.Http;
using Repository;
using Repository.Entities;

namespace Web.API.Controllers
{
    public class ConfigController : ApiController
    {
        readonly IConfigRepository _configRepository;

        public ConfigController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        // GET: api/Config
        public IEnumerable<Config> Get()
        {
            IReadOnlyList<Config> configs = _configRepository.GetAll();
            return configs;
        }

        // GET: api/Config/5
        public Config Get(int id)
        {
            Config config = _configRepository.GetById(id);
            return config;
        }

        // POST: api/Config
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Config/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Config/5
        public void Delete(int id)
        {
        }
    }
}
