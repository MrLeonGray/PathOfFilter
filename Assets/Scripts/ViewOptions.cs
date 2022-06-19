using System.Drawing;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class ViewOptions : MonoBehaviour
{
    public Text LootName;
    public SpriteRenderer Fill;
    public SpriteRenderer BorderTop;
    public SpriteRenderer BorderBot;
    public SpriteRenderer BorderLeft;
    public SpriteRenderer BorderRight;

    public Scrollbar RedText;
    public Scrollbar GreenText;
    public Scrollbar BlueText;
    public Scrollbar RedBackground;
    public Scrollbar GreenBackground;
    public Scrollbar BlueBackground;
    public Scrollbar RedBorder;
    public Scrollbar GreenBorder;
    public Scrollbar BlueBorder;
    public Scrollbar FontSize;

    // Update is called once per frame
    void Update()
    {
        float rt = RedText.value;
        float gt = GreenText.value;
        float bt = BlueText.value;
        LootName.color = new UnityEngine.Color(rt, gt, bt);
        LootName.fontSize = EditTools.GetFontSize(FontSize.value);

        float rbg = RedBackground.value;
        float gbg = GreenBackground.value;
        float bbg = BlueBackground.value;
        Fill.color = new UnityEngine.Color(rbg, gbg, bbg);

        float rb = RedBorder.value;
        float gb = GreenBorder.value;
        float bb = BlueBorder.value;
        UnityEngine.Color bColor = new UnityEngine.Color(rb, gb, bb);
        BorderTop.color = bColor;
        BorderBot.color = bColor;
        BorderLeft.color = bColor;
        BorderRight.color = bColor;
    }

    void MeasText1(PaintEventArgs e)
    {
        string text = LootName.text;
        Font font = LootName.font;
        Size tSize = TextRenderer.MeasureText(text, font);
    }

}
