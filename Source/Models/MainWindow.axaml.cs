using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Taskeasy_Manager.Source.Models;
public partial class MainWindow : Window
{
    private ProjectWindow projectWindow;

    public MainWindow()
    {
        InitializeComponent();
    }

    public void CreateTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Criar");
        projectWindow = new ProjectWindow();
        projectWindow.MinWidth = 640;
        projectWindow.MinHeight = 480;
        projectWindow.MaxWidth = 1080;
        projectWindow.MaxHeight = 720;
        projectWindow.Show();
    }

    public void LoadTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Carregar");
    }
}