using System.Net;
using Five.Bank.Api.Models.v1;
using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;

namespace Five.Bank.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController(ICustomerRepository repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerInputModel model, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            model.Name!,
            model.Document!,
            model.Birthday,
            model.Address);

        if (!customer.Validate()) return BadRequest(new { Message = "Dados inválidos." });

        await repository.AddAsync(customer, cancellationToken);

        return StatusCode((int)HttpStatusCode.Created, "Cliente cadastrado com sucesso!!!");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var customer = await repository.GetSingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (customer is null) return NotFound();

        var model = new CustomerOutputModel
        {
            Id = customer.Id,
            Name = customer.Name
        };

        return Ok(model);
    }
}