﻿using System.Linq.Expressions;
using System.Net;
using _5by5.InterAction.Sample.Api.Models.v1;
using _5by5.InterAction.Sample.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;

namespace _5by5.InterAction.Sample.Api.Controllers.v1;

[Route("api/v1/customers")]
[ApiController]
public sealed class CustomerController(ICustomerRepository repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerInputModel model, CancellationToken token)
    {
        var customer = new Customer(
            model.Name,
            model.Document,
            model.Birthday,
            model.Address);

        if (!customer.Validate()) return BadRequest(new { Message = "Dados inválidos." });

        await repository.AddAsync(customer, token);

        return StatusCode((int)HttpStatusCode.Created, new
        {
            Content = new CustomerOutputModel(customer.Id, customer.Name),
            Notification = "Cliente cadastrado com sucesso!!!"
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        Expression<Func<Customer, bool>> predicate = x => x.Id == id;

        var customer = await repository.GetSingleOrDefaultAsync(predicate, token);

        if (customer is null) return NotFound();

        return Ok(new
        {
            Content = new CustomerOutputModel(customer.Id, customer.Name)
        });
    }
}