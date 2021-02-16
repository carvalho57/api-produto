using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repositories;

namespace Products.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(int id)
        {
            return await _repository.GetByCategory(id);
        }

         [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var newProduct = await _repository.Create(product);
                return Ok(newProduct);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível cadastrar o produto!" });
            }
        }

    }
}