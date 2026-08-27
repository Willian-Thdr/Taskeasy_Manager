using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Models.Controller;

namespace Taskeasy_Manager.Source.Temp;

public partial class InitDataProj : Window
{
    private ProjectWindow projectWindow;

    public InitDataProj()
    {
        InitializeComponent();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
        };
    }

    private void Create(string? title)
    {
        try
        {
            if (string.IsNullOrEmpty(title))
                return;

            projectWindow = new ProjectWindow();
            projectWindow.MinWidth = 640;
            projectWindow.MinHeight = 480;
            projectWindow.MaxWidth = 1080;
            projectWindow.MaxHeight = 720;
            projectWindow.Title = title;
            projectWindow.Show();

            this.Close();
        } catch (Exception e)
        {
            NotificationWindow.Message($"ERROR: {e}");
        }
    }

    private void CreateFile(object? sender, RoutedEventArgs args)
    {
        Create(ProjName.Text);
    }
}