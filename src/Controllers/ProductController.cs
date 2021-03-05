using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repositories;

namespace Products.Controllers
{
    [ApiController]
    [Route("products")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult> Get()
        {
            return Ok(new Response(true,await _repository.Get()));
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return Ok(new Response(true, await _repository.GetById(id)));
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> GetByCategory(int id)
        {
            return Ok(new Response(true,await _repository.GetByCategory(id)));
        }

        [HttpPost]    
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
                var newProduct = await _repository.Create(product);
                return CreatedAtAction(nameof  (GetById), new {id = newProduct.Id}, newProduct);
            }
            catch
            {
                return BadRequest(new Response(false,"Não foi possível cadastrar o produto!" ));
            }
        }

    }
}