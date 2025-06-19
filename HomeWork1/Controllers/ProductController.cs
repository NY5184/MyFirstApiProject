using DTO;
using IceCreamStoreService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IIceCreamStoreServiceProduct _service;

        public ProductController(IIceCreamStoreServiceProduct service)
        {
            _service = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProductsAsync()
        {
            try
            {
                var products = await _service.GetAllProductsAsync();
                return Ok(products); // מחזיר 200 OK עם המוצרים
            }
            catch (Exception ex)
            {
                // מחזיר 500 Internal Server Error עם הודעת שגיאה
                return StatusCode(500, "there was error geting the products: " + ex.Message);
            }
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
