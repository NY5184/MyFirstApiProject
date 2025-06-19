
using IceCreamStoreService;
using Microsoft.AspNetCore.Mvc;
using DTO;

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
        public async Task<ActionResult<List<CategoryDTO>>> GetCategoriesAsync()
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
      
    }
}
