using Five.Bank.Domain.Entities.v1;

namespace Five.Bank.Domain.Contracts.v1;

public interface IAccountRepository : IRepository<Account>
{
    Task UpdateAsync(Account account);
}