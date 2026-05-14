using System.Windows;
using View.Services;
using ViewModel.ViewModel;
using ViewModel.ViewModel.Services;

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
        ViewModel.MainVM mainVM = new ViewModel.MainVM(messageService);
        this.DataContext = mainVM;
    }
}