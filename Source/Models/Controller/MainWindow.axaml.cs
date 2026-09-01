using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Taskeasy_Manager.Source.Temp;

namespace Taskeasy_Manager.Source.Models.Controller;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SaveProcess.CreateFolder();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
        };
    }

    public void CreateTask(object sender, RoutedEventArgs args)
    {
        InitDataProj init = new();
        init.Show();
    }

    public void LoadTask(object sender, RoutedEventArgs args)
    {
        OpenExplorer open = new OpenExplorer();
        open.Connect();
    }
}