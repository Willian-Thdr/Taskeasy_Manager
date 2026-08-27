using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Taskeasy_Manager.Source.Template;

namespace Taskeasy_Manager.Source.ViewModels;

public partial class SecoundViewModel : ViewModelBase
{
    public static ObservableCollection<TaskList> Rows { get; set; } = new();

    public SecoundViewModel()
    {
        InitialLines("Execute");
    }

    public void InitialLines(string verify)
    {
        switch (verify)        
        {
            case "Execute":
                for (int i = 0; i < 10; i++)
                {
                    Rows.Add(new TaskList("", "", ""));
                    Console.WriteLine(i);
                }
                break;

            default:
                IOException e = new();
                NotificationWindow.Message($"ERROR: {e}");
                break;
        }
    }
}