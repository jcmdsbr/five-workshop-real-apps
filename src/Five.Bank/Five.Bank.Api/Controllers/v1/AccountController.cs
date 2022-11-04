using Five.Bank.Api.Models.v1.Inputs;
using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using Five.Bank.Domain.Exceptions.v1;
using Microsoft.AspNetCore.Mvc;

namespace Five.Bank.Api.Controllers.v1;

[Route("api/v1/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;

    public AccountController(
        IAccountRepository accountRepository,
        ICustomerRepository customerRepository)
    {
        _accountRepository = accountRepository;
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Open([FromBody] AccountOpenInputModel model)
    {
        try
        {
            var customer = await _customerRepository.GetByIdAsync(model.CustomerId);

            if (customer is null) return BadRequest(new { Message = "Usuário inválido" });

            var account = new Account(model.CustomerId);

            account.Open(new Credit(100, "Abertura de conta"));
            await _accountRepository.AddAsync(account);

            return Ok();
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }

    [HttpPost("{id:guid}/deposit")]
    public async Task<IActionResult> Deposit(Guid id, [FromBody] AccountDepositInputModel model)
    {
        try
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account is null || account.IsClosed)
                return NotFound(new { Message = "Conta inativa ou inváida" });

            account.Deposit(new Credit(model.Amount, "Deposito em conta"));

            await _accountRepository.UpdateAsync(account);

            return Ok();
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }

    [HttpPost("{id:guid}/withdraw")]
    public async Task<IActionResult> Withdraw(Guid id, [FromBody] AccountWithdrawInputModel model)
    {
        try
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account is null || account.IsClosed)
                return NotFound(new { Message = "Conta inativa ou inváida" });

            account.Withdraw(new Debit(model.Amount, "Saque em conta"));

            await _accountRepository.UpdateAsync(account);

            return Ok();
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCurrentBalance(Guid id)
    {
        try
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account is null || account.IsClosed)
                return NotFound(new { Message = "Conta inativa ou inváida" });

            var balance = account.GetCurrentBalance();

            return Ok(new { Content = balance });
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Close(Guid id)
    {
        try
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account is null || account.IsClosed)
                return NotFound(new { Message = "Conta inativa ou inváida" });

            account.Close();

            await _accountRepository.UpdateAsync(account);

            return NoContent();
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }
}