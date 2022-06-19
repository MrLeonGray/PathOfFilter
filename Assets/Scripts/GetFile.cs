using System;
using System.Collections.Generic;
using System.IO;

public class GetFile
{
    //возвращает содержимое файла фильтра
    public static string GetFileValue()
    {
        return File.ReadAllText(GetPathToFilter());
    }

    public static string[] GetBlockFilter()
    {
        string value = GetFileValue();
        value = value.Replace("Show\n", "Show\nShow \n");
        value = value.Replace("Hide\n", "Hide\nHide \n");
        return value.Split(new[] { "Show\n", "Hide\n" }, StringSplitOptions.None);
    }

    //возвращает Dictionary со значениями блока по ключам
    public static Dictionary<string, object> GetDictionaryBlock(string block)
    {
        string[] attr = block.Split(new[] { "\n" }, StringSplitOptions.None);

        string defString = "";
        string[] defStringArray = { "", "", "" };

        Dictionary<string, object> dict = new Dictionary<string, object>()
        {
            { "isShow", defString },
            { "Class", defString },
            { "BaseType", defString },
            { "SetTextColor", defStringArray },
            { "SetBackgroundColor", defStringArray },
            { "SetBorderColor", defStringArray },
            { "SetFontSize", defString },
            { "PlayAlertSound", defStringArray },
            { "PlayEffect", defString },
            { "MinimapIcon", defStringArray },
            { "DisableDropSound", defString },
            { "CustomAlertSound", defString }
        };

        string[] filterKeys = { "Show", "Hide", "Class", "BaseType", "SetTextColor", "SetBackgroundColor", "SetBorderColor", "SetFontSize", "PlayAlertSound", "PlayEffect", "MinimapIcon", "DisableDropSound", "CustomAlertSound" };

        for (int i = 0; i < attr.Length; i++)
        {
            for (int k = 0; k < filterKeys.Length; k++)
            {
                string key = filterKeys[k];

                if (attr[i].Contains(key))
                {
                    if (k > 1)
                    {
                        bool isArray = key == "SetTextColor" || key == "SetBackgroundColor" || key == "SetBorderColor" || key == "PlayAlertSound" || key == "MinimapIcon";

                        string value = attr[i].Replace(key + " ", "");
                        value = value.Replace("    ", "");
                        value = value.Replace("\t", "");

                        dict[key] = value;
                        if (isArray)
                        {
                            object arr = value.Split(new[] { " " }, StringSplitOptions.None);
                            dict[key] = arr;
                        }

                    }
                    else
                    {
                        dict["isShow"] = attr[i];
                    }
                }
            }
        }

        return dict;
    }

    //возвращает путь к файлу фильтра (временно путь ведёт в папку проекта)
    public static string GetPathToFilter()
    {
        string path = @"%USERPROFILE%\Documents\GitHub\PathOfFilter\Assets\Source\TestFilter.filter";
        string pathTest = Environment.ExpandEnvironmentVariables(path);
        return pathTest;
    }

}