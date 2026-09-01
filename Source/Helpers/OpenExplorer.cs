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

        var startPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/Taskeasy Manager/Data";
        var startFolder = await window.StorageProvider.TryGetFolderFromPathAsync(startPath);

        var file = await window.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select one file",
                AllowMultiple = false,
                SuggestedStartLocation = startFolder,
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

        if (way == null)
        {
            window.Close();
            return;
        }

        window.Title = name;
        ReadArchive(File.ReadAllText(way));
        window.Show();
    }

    public void ReadArchive(string txt)
    {
        try 
        {
            TaskList task = new TaskList();
    
            List<string> Task = new();
            List<string> Importance = new();
            List<string> Data = new();
            List<string> Time = new();

            string? numColumn = GetBetween(txt, "ColumnNumber:", "Task:");
            string taskText = GetBetween(txt, "Task:", "Importance:");
            string importanceText = GetBetween(txt, "Importance:", "Data:");
            string dataText = GetBetween(txt, "Data:", "Time:");
            string timeText = GetBetween(txt, "Time:", "End");

            Task = taskText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToList();
            Importance = importanceText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToList();
            Data = dataText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToList();
            Time = timeText.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToList();
    
            LoadLines(int.Parse(numColumn), Task, Importance, Data, Time, "Load");
        } catch (Exception e)
        {
            NotificationWindow.Message($"ERROR: {e}");
        }
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

    public static void LoadLines(int num, List<string> tList, List<string> iList, List<string> dList, List<string> timeList, string verify)
    {
        List<string> task = new List<string>();
        List<string> importance = new List<string>();
        List<string> data = new List<string>();
        List<string> time = new List<string>();

        switch (verify)
        {
            case "Load":
                for (int i = 0; i < num; i++)
                {
                    TaskList taskList = new TaskList();

                    task.Add(tList[i].Trim());
                    importance.Add(iList[i].Trim());
                    data.Add(dList[i].Trim());
                    time.Add(timeList[i].Trim());

                    SecondViewModel.Rows.Add(taskList.Connect(task, importance, data, time));
                }

                break;
        }
    }
}