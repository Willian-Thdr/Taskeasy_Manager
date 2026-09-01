using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Taskeasy_Manager.Source.Template;

namespace Taskeasy_Manager.Source.ViewModels;

public partial class SecondViewModel : ViewModelBase
{
    public static ObservableCollection<TaskList> Rows { get; set; } = new();

    public static void InitialLines(string verify)
    {
        List<string> task = new List<string>();
        List<string> importance = new List<string>();
        List<string> data = new List<string>();
        List<string> timeList = new List<string>();

        switch (verify)        
        {
            case "Execute":
                DateTime time = DateTime.Now;
                int M = time.Minute;
                int H = time.Hour;
                int DD = time.Day;
                int MM = time.Month;

                TaskList taskList = new TaskList();

                task.Add("Demonstration");
                importance.Add("Low");
                data.Add($"{DD}/{MM}");
                timeList.Add($"{H}:{M}");

                Rows.Add(taskList.Connect(task, importance, data, timeList));
                break;

            default:
                IOException e = new();
                NotificationWindow.Message($"ERROR: {e}");
                break;
        }
    }
}