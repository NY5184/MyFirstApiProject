using Entity;
using IceCreamStoreService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IIceCreamStoreServiceCategory _service;

        public CategoryController(IIceCreamStoreServiceCategory service)
        {
            _service = service;
        }

        // GET: api/<Category>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategoriesAsync()
        {
            try
            {
                var Categorys = await _service.GetCategoriesAsync();
                return Ok(Categorys); // מחזיר 200 OK עם המוצרים
            }
            catch (Exception ex)
            {
                // מחזיר 500 Internal Server Error עם הודעת שגיאה
                return StatusCode(500, "there was error geting the Categorys: " + ex.Message);
            }
        }

        // GET api/<Category>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Category>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<Category>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<Category>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
