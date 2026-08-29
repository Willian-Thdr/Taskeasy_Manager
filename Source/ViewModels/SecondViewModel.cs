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

        switch (verify)        
        {
            case "Execute":
                for (int i = 0; i < 5; i++)
                {
                    TaskList taskList = new TaskList();

                    task.Add("");
                    importance.Add("");
                    data.Add("");

                    Rows.Add(taskList.Connect(task, importance, data));
                }
                break;

            default:
                IOException e = new();
                NotificationWindow.Message($"ERROR: {e}");
                break;
        }
    }
}