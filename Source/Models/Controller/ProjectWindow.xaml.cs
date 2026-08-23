using System;
using System.Globalization;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Template;
using Taskeasy_Manager.Source.ViewModels;

namespace Taskeasy_Manager.Source.Models;

public partial class ProjectWindow : Window
{
 
    public ProjectWindow()
    {
        InitializeComponent();
        DataContext = new SecoundViewModel();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
        };
    }

    private void CreateTask(object sender, RoutedEventArgs args)
    {
        SecoundViewModel.Rows.Add(new TaskList("", "", ""));
    }

    private void SaveProj(object sender, RoutedEventArgs args)
    {
        SaveProcess.Connect(this.Title);
    }
}