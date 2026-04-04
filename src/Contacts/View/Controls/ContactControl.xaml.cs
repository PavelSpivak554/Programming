using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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

    
}
