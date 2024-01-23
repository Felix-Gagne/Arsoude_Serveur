using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arsoude_Backend.Controllers
{
    public class HelloWorld
    {
        public string Text { get; set; } = "hello world";
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // GET: api/<UserController>
        [HttpGet]
        public HelloWorld GetWord()
        {
            var helloWorld = "hello world";
            return new HelloWorld();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
