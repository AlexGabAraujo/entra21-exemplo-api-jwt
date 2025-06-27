using APIESTUDOPROVA.Contracts.Service;
using APIESTUDOPROVA.DTO;
using APIESTUDOPROVA.Entities;
using APIESTUDOPROVA.Response;
using APIESTUDOPROVA.Response.Pessoa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace APIESTUDOPROVA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IPessoaService _service;

        public UserController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PessoaGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PessoaEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Post(PessoaInsertDTO pessoa)
        {
            return Ok(await _service.Post(pessoa));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Update(PessoaEntity pessoa)
        {
            return Ok(await _service.Update(pessoa));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<PessoaLoginTokenResponse>> Login(PessoaLoginDTO pessoa)
        {
            try
            {
                return Ok(await _service.Login(pessoa));
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

    }
}
