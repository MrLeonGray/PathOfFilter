using System.Collections.Generic;

public class EditFile
{
    //возвращает блок для фильтра с заданными параметрами
    public static void SetBlockFilter(Dictionary<string, object> block, string key, object value)
    {
        block[key] = value;
    }
}