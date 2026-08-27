using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Taskeasy_Manager.Source.Template;
using Taskeasy_Manager.Source.ViewModels;

namespace Taskeasy_Manager.Source.Models.Controller;

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
        var task = SecoundViewModel.Rows.Select(p => p.TaskColumn).ToList();
        var importance = SecoundViewModel.Rows.Select(p => p.ImportanceColumn).ToList();
        var data = SecoundViewModel.Rows.Select(p => p.DataColumn).ToList();

        SaveProcess.Connect(this.Title);
        WriteFile(WriteInfosModel(task, importance, data));
    }

    private static string WriteInfosModel(List<string> info1, List<string> info2, List<string> info3)
    {
        List<string> list = new List<string>();

        info1.ForEach(taskLine => list.Add($"Task: {taskLine}"));
        info2.ForEach(taskLine => list.Add($"Importance: {taskLine}"));
        info3.ForEach(taskLine => list.Add($"data: {taskLine}"));

        return $"""
        Task:
        {FilterWordTask(list, "Task:", "Task: ", "")}

        Importance:
        {FilterWordTask(list, "Importance:", "Importance: ", "")}

        Data:
        {FilterWordTask(list, "Data:", "Data: ", "")}
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

    public static string FilterWordTask(List<string> words, string keyWord, string remove, string replace)
    {
        string strList = string.Join(",\n", words.Where(x => x.StartsWith(keyWord)).Select(x => x.Replace(remove, replace).Trim()).Where(x => !string.IsNullOrEmpty(x)));

        return strList;
    }
}