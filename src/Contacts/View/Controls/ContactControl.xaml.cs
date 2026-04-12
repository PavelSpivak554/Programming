using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace View.Controls;

/// <summary>
/// Логика взаимодействия для ContactControl.xaml
/// </summary>
/// <remarks>
/// Представляет собой элемент управления для отображения/редактирования контакта.
/// Содержит встроенную валидацию поля телефона.
/// Допустимые символы для телефона: цифры, +, (, ), пробел, дефис.
/// </remarks>
public partial class ContactControl : UserControl
{
    /// <summary>
    /// Регулярное выражение для проверки ввода номера телефона.
    /// Разрешает только цифры, символы + ( ) пробел и дефис.
    /// </summary>
    private static readonly Regex PhoneNumberValidationRegex = new(@"^[0-9()+ -]+$");

    /// <summary>
    /// DependencyProperty для свойства <see cref="IsReadOnly"/>.
    /// </summary>
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(ContactControl));

    /// <summary>
    /// Определяет, доступны ли поля редактирования в контроле.
    /// </summary>
    /// <remarks>
    /// При установке значения true все поля ввода становятся доступными только для чтения.
    /// При false - поля доступны для редактирования.
    /// </remarks>
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    /// <summary>
    /// Инициализирует новый экземпляр элемента управления ContactControl.
    /// </summary>
    public ContactControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Обработчик события предварительного ввода текста в поле телефона.
    /// Запрещает ввод символов, не соответствующих формату номера телефона.
    /// </summary>
    /// <param name="sender">Источник события (обычно TextBox для ввода телефона).</param>
    /// <param name="e">Аргументы события, содержащие вводимый текст.</param>
    private void PhonePreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !PhoneNumberValidationRegex.IsMatch(e.Text);
    }

    /// <summary>
    /// Обработчик события вставки текста в поле телефона.
    /// Проверяет вставляемое значение на соответствие формату номера телефона.
    /// Если вставляемый текст содержит недопустимые символы, операция вставки отменяется.
    /// </summary>
    /// <param name="sender">TextBox для ввода телефона.</param>
    /// <param name="e">Вставляемые данные.</param>
    private void PhoneDataObjectPasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string pastedText = (string)e.DataObject.GetData(typeof(string));
            if (!PhoneNumberValidationRegex.IsMatch(pastedText))
            {
                e.CancelCommand();
                return;
            }
        }
        else
        {
            e.CancelCommand();
        }
    }
}