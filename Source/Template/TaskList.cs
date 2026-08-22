namespace Taskeasy_Manager.Source.Template;
public class TaskList
{
    public string Task { get; set; }
    public string Importance { get; set; }
    public string Data { get; set; }
    public TaskList(string task, string importance, string data)
    {
        Task = task;
        Importance = importance;
        Data = data;
    }
}