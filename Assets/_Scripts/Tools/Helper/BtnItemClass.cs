using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnItemClass {

    public string TitleSprite;
    public string IconSprite;
    public string BtnName;
    public string NextUITitle;

    public delegate void VoidDelegate();
    public VoidDelegate onClick;
    //消息提醒数
    public string TipMsg;
    public int TipNum;
    private bool IsEnabled;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="btnName">按钮名</param>
    /// <param name="iconSprite">Item 图标</param>
    /// <param name="titleSprite">标题文字图片,没有就填null</param>
    /// <param name="nextUiTitle">下一级UI的标题</param>
    /// <param name="callback">点击的事件</param>
    /// <param name="enabled"></param>
    public BtnItemClass(string btnName, string iconSprite, string titleSprite, string nextUiTitle, VoidDelegate callback, bool enabled = true)
    {
        this.BtnName = btnName;
        this.IconSprite = iconSprite ?? "null";
        this.TitleSprite = titleSprite ?? "null";
        this.NextUITitle = nextUiTitle;
        this.onClick = callback;
        IsEnabled = enabled;
    }

    public BtnItemClass()
    {

    }

    public static void Bind(BtnItemClass itemClass, Transform trans)
    {
        if (!string.IsNullOrEmpty(itemClass.BtnName))
            trans.name = itemClass.BtnName;

        //标题文字图片
        Image titleSprite = Finder.Find<Image>(trans, "TitleSprite");

        //图标
        Image iconSprite = Finder.Find<Image>(trans, "IconSprite");


        ////当标题图片找不到时就显示文字
        //var titleLabel = CTool.GetChildComponent<UILabel>("TitleLabel", trans);
        //if (string.IsNullOrEmpty(itemClass.TitleSprite) || itemClass.TitleSprite == "null")
        //{
        //    titleLabel.text = itemClass.NextUITitle;
        //    titleLabel.gameObject.SetActive(true);
        //}
        //else
        //{
        //    titleLabel.gameObject.SetActive(false);
        //}
    }
}
