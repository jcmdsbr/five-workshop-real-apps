using FluentValidation;
using System.Text.RegularExpressions;

namespace _5by5.InterAction.Sample.Domain.Commands.v1.CreateCustomer;
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private const int MinimumAge = 18;
    private const int MinimumNameLength = 5;
    private const int MinimumDocLength = 11;
    private readonly Regex _onlyNumbers = new(@"[^\d]", RegexOptions.Compiled, TimeSpan.FromMilliseconds(1));

    public CreateCustomerCommandValidator()
    {
        RuleFor(createCustomerCommand => createCustomerCommand.Birthday)
            .Must(createCustomerCommand => DateTime.Now.Year - createCustomerCommand.Year >= MinimumAge)
            .WithMessage("Idade deve ser maior que 18 anos!"); // TODO colocar essas mensagens em constantes para poder fazer validação no teste

        RuleFor(createCustomerCommand => createCustomerCommand.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .MinimumLength(MinimumNameLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumNameLength} caracteres!");

        RuleFor(createCustomerCommand => createCustomerCommand.Document)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .Must(x => _onlyNumbers.Replace(x, string.Empty).Length == MinimumDocLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumDocLength} caracteres!");
    }
}