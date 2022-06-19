using System;
using System.IO;

public class SetFile
{
    //записывает в файл фильтра
    public static void SetFileValue(string value, string path = "")
    {
        string url = path == "" ? GetFile.GetPathToFilter() : path;
        File.WriteAllText(url, value);
    }

    //задаёт путь к фильтру
    public static string SetPathToFilter(string path)
    {
        string pathTest = Environment.ExpandEnvironmentVariables(path);
        return pathTest;
    }
}