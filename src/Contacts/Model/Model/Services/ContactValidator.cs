using FluentValidation;

namespace Model.Model.Services;

/// <summary>
/// Класс, отвечающий за валидацию полей контакта.
/// </summary>
/// <remarks>
/// - Все поля могут быть пустыми (null или пустая строка считаются валидными)
/// но на уровне mainVM мы не допускаем создания контакта с пустыми значениями
/// - Запрещённые символы в телефоне отсекаются на уровне UI
/// </remarks>
public class ContactValidator : AbstractValidator<Contact>
{
    /// <summary>
    /// Инициализирует правила валидации для модели Contact.
    /// </summary>
    public ContactValidator()
    {
        const string phoneRegexPattern = @"^[0-9()+ -]+$";

        RuleFor(contact => contact.Name)
            .MaximumLength(100)
            .When(contact => !string.IsNullOrWhiteSpace(contact.Name));

        RuleFor(contact => contact.PhoneNumber)
            .MaximumLength(100)
            .Matches(phoneRegexPattern)
            .When(contact => !string.IsNullOrWhiteSpace(contact.PhoneNumber));

        RuleFor(contact => contact.Email)
            .MaximumLength(100)
            .EmailAddress()
            .When(contact => !string.IsNullOrWhiteSpace(contact.Email));
    }
}