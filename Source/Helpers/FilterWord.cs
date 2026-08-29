using System.Collections.Generic;
using System.Linq;

namespace Taskeasy_Manager.Source.Helpers;

public class FilterWord
{
    public string FilterWordTask(List<string> words)
    {
        string strList = string.Join(",\n", words);

        return strList;
    }
}