using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public enum IconColor
{
    Red,
    Green,
    Blue,
    Brown,
    White,
    Yellow,
    Cyan,
    Grey,
    Orange,
    Pink,
    Purple
}

public class Filter : MonoBehaviour
{
    static public Scrollbar redText;
    static public Scrollbar greenText;
    static public Scrollbar blueText;
    static public Scrollbar redBackground;
    static public Scrollbar greenBackground;
    static public Scrollbar blueBackground;
    static public Scrollbar redBorder;
    static public Scrollbar greenBorder;
    static public Scrollbar blueBorder;

    static public Scrollbar fontSize;

    static public Toggle currencyToggle;
    static int[] tColor;
    static int[] bgColor;
    static int[] bColor;
    static int fSize;
    static string soundID;
    static int soundVolume;
    static string effectColor;
    static string iconColor;
    static bool isDropSound;
    static string soundPath;

    //���� ����, ������ ��� ��� ����� ��������� � ���������� ����� ��� ���������
    public static void SetFilterBlock(Toggle element)
    {
        string textFilter = GetFileValue();
        string[] blocks = textFilter.Split(new[] { "#block\n" }, StringSplitOptions.None);
        bool isEdit = false;

        currencyToggle = element;
        string baseType = currencyToggle.name;

        tColor = GetRGB(redText, greenText, blueText);
        bgColor = GetRGB(redBackground, greenBackground, blueBackground);
        bColor = GetRGB(redBorder, greenBorder, blueBorder);

        fSize = GetFontSize(fontSize);

        soundID = "0"; //id �����, ����� ��� �� 0 �� 9, �� � ����� �������� ShChaos, ��� ��� �� �� ������, ���� �� ����� �� �� ���
        soundVolume = 300; //��������� ������ �� ��������� �����, �� ��� �� ID... ��� ��� �� �� ����

        effectColor = GetIconColor(IconColor.Yellow);
        iconColor = GetIconColor(IconColor.Yellow);

        isDropSound = false;

        soundPath = "";

        string blckAttribute = GetBlockFilter(currencyToggle.isOn, baseType, tColor, bgColor, bColor, fSize, soundID, soundVolume, effectColor, iconColor, isDropSound, soundPath);

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Contains("\"" + baseType + "\""))
            {
                blocks[i] = blckAttribute;
                isEdit = true;
            }

        }

        if (!isEdit)
        {
            int i = blocks.Length - 1;
            blocks[i] = blocks[i] + "\n\n#block\n" + blckAttribute;
        }

        string result = string.Join("\n#block\n", blocks);
        SetFileValue(result);
    }

    //���������� ���������� �����
    public static int GetRound(float value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    //��������������� 3 �������� � RGB ����
    public static int[] GetRGB(Scrollbar red, Scrollbar rgeen, Scrollbar blue)
    {
        int[] RGB = { GetRound(red.value) * 255, GetRound(rgeen.value) * 255, GetRound(blue.value) * 255 };
        return RGB;
    }

    //���������� �������� ��� �������� ������� ������, �������� "��" � "��" ���������� ��������
    public static int GetFontSize(Scrollbar element)
    {
        int size = GetRound(element.value) * 27 + 18;
        return size;
    }

    //���������� ���� ������ �� ��������� (����� ���������� ��������)
    public static string GetIconColor(IconColor iColor)
    {
        return iColor switch
        {
            IconColor.Red => "Red",
            IconColor.Green => "Green",
            IconColor.Blue => "Blue",
            IconColor.Brown => "Brown",
            IconColor.White => "White",
            IconColor.Yellow => "Yellow",
            IconColor.Cyan => "Cyan",
            IconColor.Grey => "Grey",
            IconColor.Orange => "Orange",
            IconColor.Pink => "Pink",
            IconColor.Purple => "Purple",
            _ => "Grey",
        };
    }

    //���������� ���� ��� ������� � ��������� �����������
    public static string GetBlockFilter(bool isShow, string baseType, int[] textColor, int[] backgroundColor, int[] borderColor, int fontSize, string alertSoundID, int alertSoundVolume, string effect, string mmIconColor, bool isDropSound, string customSoundPath)
    {

        string show = isShow ? "Show \n" : "Hide\n";
        string soundDrop = isDropSound ? "" : "\tDisableDropSound";
        int[] tC = textColor;
        int[] bGC = backgroundColor;
        int[] bC = borderColor;

        int mmIconSize = 0;
        string mmIconShare = "Circle";

        string attributeBlock = show +
                                "\tBaseType \"" + baseType + "\"" + "\n" +
                                "\tSetTextColor " + tC[0] + " " + tC[1] + " " + tC[2] + "\n" +
                                "\tSetBackgroundColor " + bGC[0] + " " + bGC[1] + " " + bGC[2] + "\n" +
                                "\tSetBorderColor " + bC[0] + " " + bC[1] + " " + bC[2] + "\n" +
                                "\tSetFontSize " + fontSize + "\n" +
                                "\tPlayAlertSound " + alertSoundID + " " + alertSoundVolume + "\n" +
                                "\tPlayEffect " + effect + "\n" +
                                "\tMinimapIcon " + mmIconSize + " " + mmIconColor + " " + mmIconShare + "\n" +
                                soundDrop +
                                "\tCustomAlertSound \"" + customSoundPath + "\"";
        return attributeBlock;
    }

    //���������� � ���� �������
    public static void SetFileValue(string value)
    {
        File.WriteAllText(PathToFilterFolder(), value);
    }

    //���������� ���������� ����� �������
    public static string GetFileValue()
    {
        return File.ReadAllText(PathToFilterFolder());
    }

    //���������� ���� � ����� ������� (�������� ���� ���� � ����� �������)
    public static string PathToFilterFolder()
    {
        string path = @"%USERPROFILE%\My project\Assets\Source\TestFilter.filter";
        string pathTest = Environment.ExpandEnvironmentVariables(path);
        return pathTest;
    }

}
