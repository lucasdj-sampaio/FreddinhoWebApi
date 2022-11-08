using FreddinhoWebApi.Interfaces;
using FreddinhoWebApi.Models.Entity;
using FreddinhoWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FreddinhoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessController : ControllerBase
    {
        private EntityRepository _repository { get; set; }

        public AcessController(EntityRepository repository) =>
            _repository = repository;


        [HttpGet("/validcredential")]
        public async Task<bool> Get([FromHeader] string email, [FromHeader] string password) =>
            await _repository.UserExist(email, password);

        [HttpGet("/isalive")]
        public async Task<IActionResult> IsAlive()
        {
            return Ok();
        }
            
        [HttpPost("/createnewaccount")]
        public async Task<(bool, string)> Post([FromBody] Account account) =>
            await _repository.InsertUser(account);


        [HttpPost("/adddependent")]
        public async Task<(bool, string)> Post([FromBody] Dependent account) =>
            await _repository.InsertUser(account);
    }
}