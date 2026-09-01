using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Models.Controller;
using Taskeasy_Manager.Source.ViewModels;

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

            ProjectWindow.load = false;
            projectWindow = new ProjectWindow();
            projectWindow.MinWidth = 640;
            projectWindow.MinHeight = 480;
            projectWindow.MaxWidth = 1080;
            projectWindow.MaxHeight = 720;
            projectWindow.Title = title;
            SecondViewModel.InitialLines("Execute");
            projectWindow.Show();

            this.Close();
        } catch (Exception e)
        {
            NotificationWindow.Message($"ERROR: {e}");
        }
    }

    private void CreateFile(object? sender, RoutedEventArgs args)
    {
        string title = new string(ProjName.Text.Where(char.IsLetterOrDigit).ToArray());

        if (!ProjName.Text.Contains(@"[^a-zA-Z0-9\s]"))
        {
            NotificationWindow.Message("O nome do arquivo deve conter apenas números e letras.");
        } 
        else if (string.IsNullOrEmpty(ProjName.Text))
        {
            NotificationWindow.Message("ERROR: Preencha todos o campo do nome.");    
        }

        Create(title);
    }
}