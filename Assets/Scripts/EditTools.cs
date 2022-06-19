using System;

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

public class EditTools
{
    //возвращает блок для фильтра
    public static string GetNewBlock(string BaseType)
    {
        string defBlock = "Show" +
                            "Class \"Gems\"" +
                            "BaseType \"" + BaseType + "\"" +
                            "SetFontSize 45" +
                            "SetTextColor 0 0 0" +
                            "SetBackgroundColor 255 0 0" +
                            "SetBorderColor 0 0 0" +
                            "SetFontSize 45" +
                            "PlayAlertSound 6 300" +
                            "PlayEffect Red" +
                            "MinimapIcon 0 Red Circle" +
                            "DisableDropSound";
        return defBlock;
    }

    //возвращает округлённое число
    public static int GetRound(float value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    //преобразовывает 3 ползунка в RGB цвет
    public static string[] GetRGB(float red, float green, float blue)
    {
        string R = (GetRound(red) * 255).ToString();
        string G = (GetRound(green) * 255).ToString();
        string B = (GetRound(blue) * 255).ToString();
        string[] RGB = { R, G, B };
        return RGB;
    }

    //возвращает значение для ползунка размера текста, значения "от" и "до" ограничены фильтром
    public static int GetFontSize(float fSize)
    {
        int size = GetRound(fSize * 27 + 18);
        return size;
    }

    //возвращает цвет иконки на миникарте (цвета ограничены фильтром)
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
}
