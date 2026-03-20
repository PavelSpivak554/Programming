using System.Windows;
using View.Services;
using View.ViewModel;
using View.ViewModel.Services;

namespace View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        IMessageService messageService = new WindowsMessageService();
        MainVM mainVM = new MainVM(messageService);
        this.DataContext = mainVM;
    }
}