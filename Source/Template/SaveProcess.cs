using System;
using System.IO;

public class SaveProcess
{
    public static void Connect(string title)
    {
        string mainWay = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    
        string save = Path.Combine(mainWay, "Taskeasy Manager");
    
        if (!Directory.Exists(save))
        {
            try
            {
                Directory.CreateDirectory(save);
            } catch(Exception e)
            {
                NotificationWindow.Message($"ERROR: {e}");
            }
        }
        
        string dataFile= Path.Combine(save, "Data");
    
        if (!Directory.Exists(dataFile))
        {
            try
            {
                Directory.CreateDirectory(dataFile);
            } catch(Exception e)
            {
                NotificationWindow.Message($"ERROR: {e}");
            }
        }
    
        string fileName = Path.Combine(dataFile, $"{title}.tasman");
    
        if (Directory.Exists(fileName))
        {
            try{}
            catch (Exception e)
            {
                NotificationWindow.Message($"ERROR: {e}");
            }
        }
    
        File.WriteAllText(fileName, "");
    }
}