using System.Collections.Generic;
using System.Linq;

namespace Taskeasy_Manager.Source.Helpers;

public class FilterWord
{
    public string FilterWordTask(List<string> words, string keyWord, string remove, string replace)
    {
        string strList = string.Join(",\n", words.Where(x => x.StartsWith(keyWord)).Select(x => x.Replace(remove, replace).Trim()).Where(x => !string.IsNullOrEmpty(x)));

        return strList;
    }
}