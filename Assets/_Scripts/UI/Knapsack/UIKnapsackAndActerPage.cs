using UnityEngine;
using System.Collections;
using TinyTeam.UI;

public class UIKnapsackAndActerPage : TTUIPage
{

    public UIKnapsackAndActerPage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UIKnapsackAndActer;
    }

    public override void Awake(GameObject go)
    {
        ShowPage<UIKnapsackPage>();
    }
}
