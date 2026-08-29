using System;
using System.Collections.Generic;
using System.Linq;

namespace Taskeasy_Manager.Source.Template;
public class TaskList
{
    public string TaskColumn { get; set; }
    public string ImportanceColumn { get; set; }
    public string DataColumn { get; set; }

    public TaskList Connect(List<string> task, List<string> importance, List<string> data)
    {
        task.ForEach(x => connectTask(x));
        importance.ForEach(x => connectImportance(x));
        data.ForEach(x => connectData(x));

        return this;
    }

    private void connectTask(string text)
    {
        TaskColumn = text;
    }

    private void connectImportance(string text)
    {
        ImportanceColumn = text;
    }

    private void connectData(string text)
    {
        DataColumn = text;
    }
}