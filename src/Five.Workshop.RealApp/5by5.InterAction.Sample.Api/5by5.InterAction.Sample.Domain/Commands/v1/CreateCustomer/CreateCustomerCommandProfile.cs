using _5by5.InterAction.Sample.Domain.Entities.v1;
using AutoMapper;
using System.Text.RegularExpressions;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
public class CreateCustomerCommandProfile : Profile
{
    private readonly Regex _onlyNumbers = new(@"[^\d]", RegexOptions.Compiled, TimeSpan.FromMilliseconds(1));
    public CreateCustomerCommandProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(fieldOutput => fieldOutput.Document, option => option
                .MapFrom(input => new String(input.Document.Where(Char.IsDigit).ToArray())));

        CreateMap<Customer, CreateCustomerCommandResponse>();
    }
}