using Microsoft.AspNetCore.Mvc;
using WebCRUDCore.cs.Interfaces;
using WebCRUDModel.cs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreaterController : ControllerBase
    {
        private readonly ICustomerCreator _customerCreator;

        public CustomerCreaterController(ICustomerCreator customerCreator)
        {
            _customerCreator = customerCreator;
        }



        // GET: api/<CustomerCreaterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerCreaterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerCreaterController>
        [HttpPost]
        public void Post([FromBody] CustomerReqestmodel customerReqestmodel)
        {
            _customerCreator.CreateCustomer(customerReqestmodel);
        }

        // PUT api/<CustomerCreaterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerCreaterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
