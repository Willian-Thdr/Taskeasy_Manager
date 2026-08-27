namespace Taskeasy_Manager.Source.Template;
public class TaskList
{
    public string TaskColumn { get; set; }
    public string ImportanceColumn { get; set; }
    public string DataColumn { get; set; }
    public TaskList(string task, string importance, string data)
    {
        TaskColumn = task;
        ImportanceColumn = importance;
        DataColumn = data;
    }
}