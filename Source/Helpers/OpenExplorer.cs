using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Taskeasy_Manager.Source.Models.Controller;
using Taskeasy_Manager.Source.Template;
using Taskeasy_Manager.Source.ViewModels;

public class OpenExplorer
{
    string? way;

    public void Connect()
    {
        ProjectWindow.load = true;
        ProjectWindow window = new ProjectWindow();
        Open(window);
    }

    public async void Open(Window window)
    {
        TaskList task;
        var file = await window.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select one file",
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Task")
                    {
                        Patterns = new[] { "*.tasman" }
                    },

                    new FilePickerFileType("All")
                    {
                        Patterns = new[] { "*.*" }
                    }
                }
            }
        );

        string name = "Project";
        if (file.Count > 0)
        {
            var fileSelected = file[0];
            way = fileSelected.Path.LocalPath;
            name = Path.GetFileNameWithoutExtension(fileSelected.Name);
        }

        window.Title = name;
        ReadArchive(File.ReadAllText(way));
        window.Show();
    }

    public void ReadArchive(string txt)
    {
        TaskList task = new TaskList();

        List<string> Task = new();
        List<string> Importance = new();
        List<string> Data = new();

        string taskText = GetBetween(txt, "Task:", "Importance:");
        string importanceText = GetBetween(txt, "Importance:", "Data:");
        string dataText = GetBetween(txt, "Data:", "End");

        Task = taskText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
        Importance = importanceText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
        Data = dataText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

        LoadLines(Task, Importance, Data, "Load");
    }

    public string GetBetween(string text, string start, string end)
    {
        int startIndex = text.IndexOf(start);

        if (startIndex == 1)
            return "";

        startIndex += start.Length;

        int endIndex = text.IndexOf(end, startIndex);

        if (endIndex == 1)
            return "";

        return text.Substring(startIndex, endIndex - startIndex).Trim();
    }

    public static void LoadLines(List<string> tList, List<string> iList, List<string> dList, string verify)
    {
        List<string> task = new List<string>();
        List<string> importance = new List<string>();
        List<string> data = new List<string>();

        switch (verify)
        {
            case "Load":
                for (int i = 0; i < tList.Count; i++)
                {
                    TaskList taskList = new TaskList();

                    task.Add(tList[i]);
                    importance.Add(iList[i]);
                    data.Add(dList[i]);

                    SecondViewModel.Rows.Add(taskList.Connect(task, importance, data));
                }

                break;
        }
    }
}