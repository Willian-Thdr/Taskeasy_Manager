using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Template;
using Taskeasy_Manager.Source.ViewModels;
using Taskeasy_Manager.Source.Helpers;
using System.Threading.Tasks;
using Avalonia.VisualTree;
using Avalonia.Media;
using Avalonia.Input;

namespace Taskeasy_Manager.Source.Models.Controller;

public partial class ProjectWindow : Window
{
    public static bool load = false;

    public ProjectWindow()
    {
        InitializeComponent();

        DataContext = new SecondViewModel();

        this.Closing += (s, e) =>
        {
            e.Cancel = false;
            SecondViewModel.Rows.Clear();
        };
    }

    private void CreateTask(object sender, RoutedEventArgs args)
    {
        TaskList taskList = new TaskList();
        DateTime time = DateTime.Now;
        int M = time.Minute;
        int H = time.Hour;
        int DD = time.Day;
        int MM = time.Month;

        List<string> task = [""];
        List<string> importance = [""];
        List<string> data = [$"{DD}/{MM}"];
        List<string> hour = [$"{H}:{M}"];

        SecondViewModel.Rows.Add(taskList.Connect(task, importance, data, hour));
    }

    private void SaveProj(object sender, RoutedEventArgs args)
    {
        var task = SecondViewModel.Rows.Select(p => p.TaskColumn).ToList();
        var importance = SecondViewModel.Rows.Select(p => p.ImportanceColumn).ToList();
        var data = SecondViewModel.Rows.Select(p => p.DataColumn).ToList();
        var time = SecondViewModel.Rows.Select(p => p.TimeColumn).ToList();

        SaveProcess.Connect(this.Title);
        WriteFile(WriteInfosModel(task, importance, data, time));
    }

    public static string WriteInfosModel(List<string> info1, List<string> info2, List<string> info3, List<string> info4)
    {
        FilterWord filter = new FilterWord();

        return $"""
        ColumnNumber: {SecondViewModel.Rows.Count}

        Task:
        {filter.FilterWordTask(info1)}

        Importance:
        {filter.FilterWordTask(info2)}

        Data:
        {filter.FilterWordTask(info3)}

        Time:
        {filter.FilterWordTask(info4)}

        End
        """;
    }

    private void WriteFile(string txt)
    {
        string way = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string save = Path.Combine(way, "Taskeasy Manager");
        string data = Path.Combine(save, "Data");
        string fileName = Path.Combine(data, $"{this.Title}.tasman");

        try
        {
            File.WriteAllText(fileName, txt.ToString());
        }
        catch (Exception e)
        {
            File.WriteAllText(fileName, $"ERROR: {e}");
        }
    }


    private void Randomized(object sender, RoutedEventArgs args)
    {
        List<string> tList = SecondViewModel.Rows.Select(t => t.TaskColumn).ToList();
        int selectIndex = 0;
        bool randomized = false;

        selectIndex = Random.Shared.Next(1, tList.Count+1); // Sempre que for utilizar, subtrair por 1.        
        randomized = true;
        Highlight(selectIndex, randomized);
        randomized = false;
    }

    private void Highlight(int selectIndex, bool randomized)
    {
        if (randomized == true)
        {
            foreach (var row in GridList.GetVisualDescendants().OfType<DataGridRow>())
            {
                if (row.Index == selectIndex-1)
                    row.Background = new SolidColorBrush(Color.Parse("#4e8be6"));
                else
                    row.Background = Brushes.Transparent;

                this.KeyDown += (s, e) =>
                {
                    if (e.Key == Key.Escape)
                    {
                        row.Background = Brushes.Transparent;
                    }
                };
            }            
        }
    }

    private void Delete(object sender, RoutedEventArgs args)
    {
        if (GridList.SelectedItem is TaskList selectedTask)
        {
            SecondViewModel.Rows.Remove(selectedTask);
        }
    }
}