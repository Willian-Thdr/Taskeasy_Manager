using Avalonia.Controls;

namespace Taskeasy_Manager.Source.Models;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.WindowState = WindowState.Maximized;
        InitializeComponent();
    }
}