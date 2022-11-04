using System.Net;
using Five.Bank.Api.Models.v1;
using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Five.Bank.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController : ControllerBase
{

    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerInputModel model)
    {

        //TODO implementar validação de nome.
        var customer = new Customer(model.Name, 
            model.Document, 
            model.Birthday, 
            model.Address);

        if (!customer.Validate())
        {
            return BadRequest(new { Message = "Dados inválidos." });
        }

        await _repository.AddAsync(customer);

        return StatusCode((int)HttpStatusCode.Created, "Cliente cadastrado com sucesso!!!");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        // TODO instalar, configurar e implementar Automapper.

        var customer = await _repository.GetByIdAsync(id);

        if (customer is null) return NotFound();

        var model = new CustomerOutputModel
        {
            Id = customer.Id,
            Name = customer.Name
        };

        return Ok(model);
    }
}