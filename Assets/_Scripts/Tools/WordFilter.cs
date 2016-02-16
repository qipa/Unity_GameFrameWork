using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// 字符过滤
/// </summary>
public class WordFilter : UnitySingleton<WordFilter>
{

    public string[] m_StringFilters;
    private const char Replacement = '*';
    public Dictionary<int, string> m_Replacers = new Dictionary<int, string>();
    public void Awake()
    {
        
        //m_StringFilters = Regex.Split(textAsset.text, "\n");
    }

    public string FilterString(string str)
    {
        //string ReplaceStr = str;
        //IEnumerator en = m_StringFilters.GetEnumerator();
        //string strItem = null;
        //while (en.MoveNext())
        //{
        //    strItem = (string)en.Current;
        //    if (strItem.Trim() != "")
        //    {
        //        if (str.IndexOf(strItem) != -1)
        //            str = str.Replace(strItem, "***");
        //    }
        //}
        return filterXSS(str);
    }
    /// <summary>
    /// 进行指定的替换(脏字过滤)
    /// </summary>
    public string StrFilter(string str)
    {
        string text1 = "", text2 = "";
        TextAsset textAsset = Resources.Load<TextAsset>("Txt/FilterString");
        string[] textArray1 = SplitString(textAsset.text, "\r\n");
        Debug.Log(textArray1.Length);
        for (int num1 = 0; num1 < textArray1.Length; num1++)
        {
            text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
            text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
            str = str.Replace(text1, text2);
        }
        return str;
    }

    /// <summary>
    /// 分割字符串
    /// </summary>
    public static string[] SplitString(string strContent, string strSplit)
    {
        if (!string.IsNullOrEmpty(strContent))
        {
            if (strContent.IndexOf(strSplit) < 0)
                return new string[] { strContent };

            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }
        else
            return new string[0] { };
    }

    public string filterXSS(string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            string[] strs = new string[2];
            strs[0] = "ss";
            strs[1] = "周旋";
            TextAsset textAsset = Resources.Load<TextAsset>("Txt/FilterString");
            if (textAsset != null)
                m_StringFilters = RandomHelper.getStringToArray(textAsset.text.ToString(), '\n');
            for (int i = 0; i < m_StringFilters.Length; i++)
            {
                if (str.Equals(m_StringFilters[i]))
                {
                    str = str.Replace(m_StringFilters[i], "***");
                    Debug.Log(str + strs.Length);
                }
            }
        }
        return str;
    }
}

