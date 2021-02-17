using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repositories;
using Products.Services;

namespace Products.Controllers
{

    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _repository.Create(user);
                return Ok(new {message = "Usuario cadastrado com sucesso!"});
            }
            catch
            {
                return BadRequest(new {message = "Não foi possível criar o usuário"});
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] User user)
        {
            var validUser = await _repository.Authenticate(user.Username, user.Password);

            if(validUser == null)
                return NotFound(new {message = "Usuário ou senha inválidos!"});
            
            return Ok(GenerateTokenService.GenerateToken(validUser));
        }

    }
}