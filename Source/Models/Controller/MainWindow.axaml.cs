using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Temp;

namespace Taskeasy_Manager.Source.Models.Controller;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
        };
    }

    public void CreateTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Criar");
        InitDataProj init = new();
        init.Show();
    }

    public void LoadTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Carregar");
    }
}