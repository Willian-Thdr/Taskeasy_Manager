using Avalonia.Controls;

namespace Taskeasy_Manager.Source.Models;

public partial class ProjectWindow : Window
{
    public ProjectWindow()
    {
        InitializeComponent();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
        };
    }
}