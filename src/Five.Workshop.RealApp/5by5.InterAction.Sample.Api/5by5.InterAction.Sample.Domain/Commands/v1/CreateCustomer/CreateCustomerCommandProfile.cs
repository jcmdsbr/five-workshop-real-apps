using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using System;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
public class CreateCustomerCommandProfile : Profile
{
    public CreateCustomerCommandProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(fieldOutput => fieldOutput.Document, option => option
                .MapFrom(input => input.Name));

        //CreateMap<Customer, CreateCustomerCommandResponse>();
    }

    public static string GetOnlyNumbers(string text)
    {
        var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
        return stringNumber;
    }
}