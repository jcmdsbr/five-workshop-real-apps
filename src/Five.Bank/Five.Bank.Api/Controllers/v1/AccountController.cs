using Five.Bank.Api.Models.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Five.Bank.Api.Controllers.v1
{
    [Route("api/v1/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //TODO Adicionar o repositório AccountRepository

        [HttpPost]
        public async Task<IActionResult> Open([FromBody] AccountOpenInputModel model)
        {
            //TODO abrir a conta
            // Adicionar uma transação do tipo crédito de R$ 100

            //Salvar no repositorio
            //Retornar sucesso

            // id customer
            // var account = new Account(model.Id);
            // account.Open(new Credit(100))//100
            // _repository.AddAsync(account);

            return await Task.FromResult(Ok());
        }

        [HttpPost("{id:guid}/deposit")]
        public async Task<IActionResult> Deposit(Guid id, [FromBody] AccountDepositInputModel model)
        {
            // TODO realizar o deposito
            //Retornar sucesso
            return await Task.FromResult(Ok());
        }

        [HttpPost("{id:guid}/withdraw")]
        public async Task<IActionResult> Withdraw(Guid id,[FromBody] AccountDepositInputModel model)
        {
            // TODO realizar o saque
            //Retornar sucesso
            return await Task.FromResult(Ok());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCurrentBalance(Guid id)
        {
            // Buscar o saldo da conta pelo id
            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Close(Guid id)
        {
            // Fechar a conta
            return await Task.FromResult(Ok());
        }

    }
}
