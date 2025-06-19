using DTO;
using IceCreamStoreService;
using Microsoft.AspNetCore.Mvc;
using IceCreamStoreService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IIceCreamStoreServiceOrder _service;

        public OrderController(IIceCreamStoreServiceOrder service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
     
      

        // GET api/<OrderController>/5
      

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO orderDto)
        {
            try
            {
                var newOrder = await _service.AddOrderAsync(orderDto);
                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
