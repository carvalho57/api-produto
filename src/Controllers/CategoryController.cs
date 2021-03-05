using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Models;
using Products.Repositories;

// Endpoint -> URL
namespace Products.Controllers
{
    [ApiController]
    [Route("categories")]
   // [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null)
                return NotFound(new Response(false, "Categoria não foi encontrada!"));
            return Ok(new Response(true, category));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _repository.Get();
            return Ok(new Response(true, categories));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            try
            {
                var newCategory = await _repository.Create(category);
                return Ok(new Response(true, newCategory));
            }
            catch
            {
                return BadRequest(new Response(false, "Não foi possível cadastrar a categoria!"));
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Put([FromBody] Category category, int id)
        {
            if (category.Id != id)
                return NotFound(new Response(false, "A categoria não foi encontrada!"));

            try
            {
                await _repository.Update(category);
                return Ok(new Response(true,"Categoria atualizada com sucesso!"));
            }
            catch
            {
                return BadRequest(new Response(false, "Não foi possível atualizar a categoria!" ));
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null) return NotFound(new Response(false,"A categoria não foi encontrada!" ));

            try
            {
                await _repository.Delete(category);
                return Ok(new Response(true, "Categoria removida com sucesso!"));
            }
            catch
            {
                return BadRequest(new Response(false,"Não foi possível remover a categoria!"));
            }
        }

    }
}
