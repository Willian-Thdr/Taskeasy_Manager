using System;
using System.Collections.Generic;
using System.Linq;
using Taskeasy_Manager.Source.ViewModels;

namespace Taskeasy_Manager.Source.Helpers;

public class FilterWord
{
    public string FilterWordTask(List<string> words)
    {
        List<string> newWords = new();

        foreach (string txt in words)
        {
            if (string.IsNullOrEmpty(txt))
            {
                newWords.Add("NaN");
            }
            else
            {
                newWords.Add(txt);                
            }
        }

        string strList = string.Join(",\n", newWords);

        return strList.Trim();
    }
}

// NotificationWindow.Message("ERROR: Fill in all the fields.");