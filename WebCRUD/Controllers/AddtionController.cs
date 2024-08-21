using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddtionController : ControllerBase
    {
        private readonly IAddition _addition;

        public AddtionController(IAddition addition)
        {
          _addition = addition;
        }



        // GET: api/<AddtionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddtionController>/5
        [HttpGet("{id}")]
        public   void Get(int id)
        {

        }
        // POST api/<AddtionController>
        [HttpPost]
        public int Post([FromBody] Addition addition)
        {
            return _addition.AddTwoNumber(addition.a, addition.b);
        }

        // PUT api/<AddtionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddtionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
