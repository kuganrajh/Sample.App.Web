using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.App.Domain.SQL;
using Sample.App.Infrastructure.Interface;

namespace Sample.App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<Order> _orderService;

        public OrderController(IService<Order> orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.Get();
            return Ok(orders); // JSON response
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order); // JSON response
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrder = await _orderService.CreateAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder); // JSON response
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Order order)
        {
            if (id != order.Id)
                return BadRequest("Order ID mismatch");

            var updatedOrder = await _orderService.UpdateAsync(order);
            return Ok(updatedOrder); // JSON response
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _orderService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent(); // No response body
        }
    }
}
