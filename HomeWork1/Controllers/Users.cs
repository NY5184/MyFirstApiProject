
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IceCreamStoreService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        IceCreamStoreServiceUser service = new IceCreamStoreServiceUser();
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Users>
        [HttpPost("register")]
        public User  addUserRegister([FromBody] User newUser)
        {
           return service.addUserRegister(newUser);

        }

        //POST api/<Users>
        [HttpPost("logIn")]
        public User getUserByUserNameAndPasswordLogin([FromBody] UserLogin userLogin)
        {
            return service.getUserByUserNameAndPasswordLogin(userLogin);

        }

        //PUT api/<Users>
        [HttpPut("{id}")]
        public User UpdateUser(int id, [FromBody] User updatedUser)
        {

            return service.UpdateUser(id,updatedUser);

        }




        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}