using System.Net;
using Five.Bank.Api.Models.v1.Inputs;
using Five.Bank.Api.Models.v1.Outputs;
using Five.Bank.Domain.Contracts.v1;
using Five.Bank.Domain.Entities.v1;
using Five.Bank.Domain.Exceptions.v1;
using Microsoft.AspNetCore.Mvc;

namespace Five.Bank.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IAddressClient _addressClient;

    public CustomerController(
        ICustomerRepository repository, 
        IAddressClient addressClient)
    {
        _repository = repository;
        _addressClient = addressClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerInputModel model)
    {
        try
        {
            var address = await _addressClient.GetByZipCode(model.ZipCode);

            if(address is null) return BadRequest(new { Message = "Dados inválidos." });

            var customer = new Customer(
                model.Name,
                model.Document,
                model.Birthday,
                address);

            if (!customer.Validate()) return BadRequest(new { Message = "Dados inválidos." });
           
            await _repository.AddAsync(customer);

            return StatusCode((int)HttpStatusCode.Created, "Cliente cadastrado com sucesso!!!");
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer is null) return NotFound();

            var model = new CustomerOutputModel(customer.Id, customer.Name);

            return Ok(model);
        }
        catch (DomainException e)
        {
            return BadRequest(new { e.Message });
        }
    }
}