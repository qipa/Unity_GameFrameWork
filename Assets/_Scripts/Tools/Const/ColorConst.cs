using UnityEngine;
using System.Collections;
using System.Text;

public class ColorConst {

    static StringBuilder sb = new StringBuilder();
    public const string Green = "25da13";     //绿色
    public const string Red = "ff0000";       //红色
    public const string HeSe = "d7cfa6";      //褐色
    public const string Juhuang = "d27910";   //橘黄
    public const string LiangHuang = "fce449";//亮黄
    public const string Pink = "c43e86";      //粉色
    public const string Blue = "41b1ff";      //蓝色

    public static string Format(string color, string value)
    {
        return string.Format("[{0}]{1}[-]", color, value);
    }
    public static string Format(string color, object value)
    {
        return string.Format("[{0}]{1}[-]", color, value);
    }
    public static string Format(string color, params object[] args)
    {
        sb = new StringBuilder();
        string start = string.Format("[{0}]", color);
        for (int i = 0; i < args.Length; i++)
            sb.Append(args[i].ToString());
        string end = "[-]";
        return start + sb.ToString() + end;
    }
}
