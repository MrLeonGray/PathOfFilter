using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static void SelectCurrency(Toggle elem)
    {
        string name = elem.name;
        string[] blocks = GetFile.GetBlockFilter();
        for (int i = 0; i < blocks.Length; i++)
        {
            string block = blocks[i];
            bool isBlock = block.Contains("Show") || block.Contains("Hide");
            if (block == "" || !isBlock)
            {
                continue;
            }
            Dictionary<string, object> bl = GetFile.GetDictionaryBlock(block);
        }
    }
}