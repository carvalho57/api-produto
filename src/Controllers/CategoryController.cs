using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Models;
using Products.Repositories;

// Endpoint -> URL
namespace Products.Controllers
{

    [Route("categories")]
    public class CategoryController : ControllerBase
    {

        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null)
                return NotFound(new { message = "Categoria não foi encontrada!" });
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _repository.Get();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var newCategory = await _repository.Create(category);
                return Ok(newCategory);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível cadastrar a categoria!" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Put([FromBody] Category category, int id)
        {
            if (category.Id != id)
                return NotFound(new { message = "A categoria não foi encontrada!" });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _repository.Update(category);
                return Ok(new { message = "Categoria atualizada com sucesso!" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria!" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null) return NotFound(new { message = "A categoria não foi encontrada!" });

            try
            {
                await _repository.Delete(category);
                return Ok(new { message = "Categoria removida com sucesso!" });
            }catch{
                return BadRequest(new {message = "Não foi possível remover a categoria!"} );
            }
        }

    }
}