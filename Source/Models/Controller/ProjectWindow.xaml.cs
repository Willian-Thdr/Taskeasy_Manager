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

        List<string> task = [""];
        List<string> importance = [""];
        List<string> data = [""];

        SecondViewModel.Rows.Add(taskList.Connect(task, importance, data));
    }

    private void SaveProj(object sender, RoutedEventArgs args)
    {
        var task = SecondViewModel.Rows.Select(p => p.TaskColumn).ToList();
        var importance = SecondViewModel.Rows.Select(p => p.ImportanceColumn).ToList();
        var data = SecondViewModel.Rows.Select(p => p.DataColumn).ToList();

        SaveProcess.Connect(this.Title);
        WriteFile(WriteInfosModel(task, importance, data));
    }

    public static string WriteInfosModel(List<string> info1, List<string> info2, List<string> info3)
    {
        FilterWord filter = new FilterWord();

        return $"""
        Task:
        {filter.FilterWordTask(info1)}

        Importance:
        {filter.FilterWordTask(info2)}
        
        Data:
        {filter.FilterWordTask(info3)}

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
        } catch (Exception e)
        {
            File.WriteAllText(fileName, $"ERROR: {e}");
        }
    }
}