namespace View.Model.Services;
using FluentValidation;
using View.ViewModel;

/// <summary>
/// Класс, отвечающий за валидацию полей контакта
/// </summary>
public class ContactValidator : AbstractValidator<Contact>
{
    /// <summary>
    /// Конструктор для валидациии
    /// </summary>
    public ContactValidator()
    {
        RuleFor(contact => contact.Name)
            //.NotEmpty()
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(contact => contact.PhoneNumber)
            //.NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[0-9()+ -]+$")
            .When(contact => !string.IsNullOrWhiteSpace(contact.PhoneNumber));

        RuleFor(contact => contact.Email)
            //.NotEmpty()
            .MaximumLength(100)
            .EmailAddress()
            .When(contact => !string.IsNullOrWhiteSpace(contact.Email));
    }
}
