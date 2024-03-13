using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace oopDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _repository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!_repository.Add(product))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null || id != product.ID)
            {
                return BadRequest();
            }
            if (_repository.Get(id) == null)
            {
                return NotFound();
            }
            if (!_repository.Update(product))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Get(id) == null)
            {
                return NotFound();
            }
            if (!_repository.Delete(id))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }
}
