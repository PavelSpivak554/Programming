using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace View.Controls;

/// <summary>
/// Логика взаимодействия для ContactControl.xaml
/// </summary>
public partial class ContactControl : UserControl
{
    public ContactControl()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(ContactControl));

    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    private readonly Regex PhoneRegex = new(@"^[0-9()+ -]+$");
    private void PhonePreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string text = e.Text;
        e.Handled = !PhoneRegex.IsMatch(e.Text);
    }
    private void PhoneDataObjectPasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string pastedText = (string)e.DataObject.GetData(typeof(string));
            if (!PhoneRegex.IsMatch(pastedText))
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

