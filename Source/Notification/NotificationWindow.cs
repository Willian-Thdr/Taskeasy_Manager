using System;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Media;

public class NotificationWindow
{
    public static void Message(String text)
    {
        Window message = new Window
        {
            Width = double.NaN,
            Height = 300,
            Background = new SolidColorBrush(Color.Parse("#d6ceb6")),
            Title = "Message Box"
        };

        Grid grid = new Grid
        {
            Margin = new Avalonia.Thickness(20)
        };

        Label txt = new Label
        {
            Content = text,
            FontSize = 16,
            Foreground = Brushes.Black,
            Margin = new Avalonia.Thickness(5),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };

        grid.Children.Add(txt);

        message.Content = grid;

        message.Show();
    }
}