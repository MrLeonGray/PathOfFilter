using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject currencyPanel;
    public GameObject orange;

    public void GetChildrensElems(GameObject panel)
    {
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            GameObject child = panel.transform.GetChild(i).gameObject;
        }
    }

    public void Start()
    {
        Screen.SetResolution(1600, 900, false);
    }

    
    public void SelectPanel(string panelName)
    {
        GameObject[] panels = { currencyPanel, orange };
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        switch (panelName)
        {
            case "currency":
                currencyPanel.SetActive(true);
                break;

            case "orange":
                orange.SetActive(true);
                break;

            default:
                break;
        }
    }

}