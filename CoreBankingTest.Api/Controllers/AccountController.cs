using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBankingTest.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountRepository.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            var account = _accountRepository.GetById(id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found");
            }
            return Ok(account);
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel account)
        {
            _accountRepository.Add(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }
    }
}
