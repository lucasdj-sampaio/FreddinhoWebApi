using FreddinhoWebApi.Interfaces;
using FreddinhoWebApi.Models.Entity;
using FreddinhoWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
namespace FreddinhoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessController : ControllerBase
    {
        private EntityRepository _repository { get; set; }

        public AcessController(EntityRepository repository) =>
            _repository = repository;


        [HttpPost("/validcredential")]
        public async Task<IActionResult> Post([FromBody] Account account) {
            try{
                return Ok(await _repository.UserExist(account.Email, account.Password));
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return BadRequest(e);
            }
        }

        [HttpPost("/getaccount")]
        public async Task<Account> GetAccount([FromBody] Account account) =>
            await _repository.ReturnAccount(account.Email, account.Password);

        [HttpPost("/getaccountid")]
        public async Task<IActionResult> GetAccountId([FromBody] Account account)
        {
            try{
                return Ok((await _repository.ReturnAccount(account.Email, account.Password)).Id);
            }catch (Exception e){
                return BadRequest(e);
            }
        }

        [HttpGet("/getdependent")]
        public async Task<IActionResult> GetDependent([FromQuery] int userId)
        {
            IList<Dependent> dep = await _repository.GetDependent(userId);
            return Ok(dep);
        }
            
        [HttpPost("/createnewaccount")]
        public async Task<(bool, string)> PostUser([FromBody] Account account) =>
            await _repository.InsertUser(account);


        [HttpPost("/adddependent")]
        public async Task<(bool, string)> Post([FromBody] Dependent account) =>
            await _repository.InsertUser(account);
    }
}