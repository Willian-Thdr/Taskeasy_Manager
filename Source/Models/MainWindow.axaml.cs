using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Taskeasy_Manager.Source.Models;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void CreateTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Criar");
    }

    public void LoadTask(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("Carregar");
    }
}