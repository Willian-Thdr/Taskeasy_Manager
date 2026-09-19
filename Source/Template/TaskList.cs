using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Taskeasy_Manager.Source.Template;
public class TaskList
{
    public string? TaskColumn { get; set; }
    public string? ImportanceColumn { get; set; }
    public string? InitialTime { get; set; }
    public string? FinalTime { get; set; }
    public string? InitialDay { get; set; }
    public string? FinalDay { get; set; }

    public TaskList Connect(List<string> task, List<string> importance, List<string> initialTime, 
    List<string> finalTime, List<string> initialDay, List<string> finalDay)
    {
        task.ForEach(x => connectTask(x));
        importance.ForEach(x => connectImportance(x));
        initialTime.ForEach(x => connectInitialHour(x));
        finalTime.ForEach(x => connectFinalHour(x));
        initialDay.ForEach(x => connectInitialDay(x));
        finalDay.ForEach(x => connectFinalDay(x));

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

    private void connectInitialHour(string text)
    {
        InitialTime = text;
    }

    private void connectFinalHour(string text)
    {
        FinalTime = text;
    }

    private void connectInitialDay(string text)
    {
        InitialDay = text;
    }

    private void connectFinalDay(string text)
    {
        FinalDay = text;
    }
}