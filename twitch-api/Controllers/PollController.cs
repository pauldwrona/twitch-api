using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace twitch_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        // GET: api/<PollController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PollController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public string Get(int id)
        {
            
            return "value";
        }

        // POST api/<PollController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PollController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PollController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
