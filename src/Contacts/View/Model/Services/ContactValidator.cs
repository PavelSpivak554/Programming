namespace View.Model.Services;
using FluentValidation;
public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(contact => contact.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(contact => contact.PhoneNumber)
            .NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[0-9()+ -]+$");

        RuleFor(contact => contact.Email)
            .NotEmpty()
            .MaximumLength(100)
            .EmailAddress();
    }
}
