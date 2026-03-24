using Microsoft.AspNetCore.Mvc;
using BankAPI.Models;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        // stockage temporaire en mémoire
        private static List<Account> accounts = new List<Account>();
        private static int nextId = 1;

        // GET /api/Accounts
        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok(accounts);
        }

        // GET /api/Accounts/{id}
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        // POST /api/Accounts
        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Le nom est requis.");

            var account = new Account
            {
                Id = nextId++,
                Name = request.Name,
                Balance = 0
            };

            accounts.Add(account);
            return Ok(account);
        }
    }
}