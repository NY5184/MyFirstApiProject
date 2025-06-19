
//using Entity;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using IceCreamStoreService;
//using System.Linq;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace HomeWork1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        IIceCreamStoreServiceUser _service;
//        public UserController(IIceCreamStoreServiceUser service)
//        {
//            _service = service;
//        }
//        // GET: api/<Users>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<Users>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<Users>
//        [HttpPost("register")]
//        public async Task<ActionResult<User>> addUserRegisterAsync([FromBody] User newUser)
//        {
//            try
//            {
//                User user = await _service.addUserRegister(newUser);
//                return Ok(user);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }

//        //POST api/<Users>
//        [HttpPost("logIn")]
//        public async Task<ActionResult<User>> getUserByUserNameAndPasswordLogin([FromBody] UserLogin userLogin)
//        {
//            try
//            {
//                User user = await _service.getUserByUserNameAndPasswordLogin(userLogin);
//                return Ok(user);
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//        }

//        //PUT api/<Users>
//        [HttpPut("{id}")]
//        public async Task<ActionResult<User>> UpdateUserAsync(int id, [FromBody] User updatedUser)
//        {
//            try
//            {
//                if (id > int.MaxValue || id < int.MinValue)
//                    return BadRequest("Id is out of range for int.");

//                int intId = (int)id;
//                User user = await _service.UpdateUser(intId, updatedUser);

//                return Ok(user);
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }


//        }




//        // DELETE api/<Users>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}

using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IceCreamStoreService;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IIceCreamStoreServiceUser _service;
        public UserController(IIceCreamStoreServiceUser service)
        {
            _service = service;
        }
        // GET: api/<Users>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<Users>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Users>
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> addUserRegisterAsync([FromBody] UserDTO newUserDto)
        {
            try
            {
                UserDTO user = await _service.addUserRegister(newUserDto);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //POST api/<Users>
        [HttpPost("logIn")]
        public async Task<ActionResult<UserDTO>> getUserByUserNameAndPasswordLogin([FromBody] UserLoginDTO userLoginDto)
        {
            try
            {
                UserDTO user = await _service.getUserByUserNameAndPasswordLogin(userLoginDto);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //PUT api/<Users>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUserAsync(int id, [FromBody] UserDTO updatedUserDto)
        {
            try
            {
                if (id > int.MaxValue || id < int.MinValue)
                    return BadRequest("Id is out of range for int.");

                int intId = (int)id;
                UserDTO user = await _service.UpdateUser(intId, updatedUserDto);

                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }




        // DELETE api/<Users>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}