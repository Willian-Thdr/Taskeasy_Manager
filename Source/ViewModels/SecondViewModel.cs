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
        List<string> initialHour = new();
        List<string> finalHour = new();
        List<string> initialDay = new();
        List<string> dinalDay = new();

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
                initialHour.Add($"{H}:{M}");
                finalHour.Add("...");
                initialDay.Add($"{DD}/{MM}");
                dinalDay.Add("...");

                Rows.Add(taskList.Connect(task, importance, initialHour, finalHour, initialDay, dinalDay));
                break;

            default:
                IOException e = new();
                NotificationWindow.Message($"ERROR: {e}");
                break;
        }
    }
}