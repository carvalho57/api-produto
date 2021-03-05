using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Repositories;
using Products.Services;

namespace Products.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            try
            {
                user.Role = ERole.Employee;
                await _repository.Create(user);
                return Ok(new Response(true, "Usuario cadastrado com sucesso"));
            }
            catch
            {
                return BadRequest(new Response(false, "Não foi possível criar o usuário"));
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            var validUser = await _repository.Authenticate(user.Username, user.Password);

            if (validUser == null)
                return NotFound(new Response(false, "Usuário ou senha inválidos!"));
            return Ok(
                new Response(
                    true,
                    "Usuário autenticado com sucesso",
                    GenerateTokenService.GenerateToken(validUser))
                );

        }

    }
}