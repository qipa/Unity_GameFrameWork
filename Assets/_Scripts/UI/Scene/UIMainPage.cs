using UnityEngine;
using System.Collections;
using TinyTeam.UI;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIMainPage : TTUIPage
{

    public UIMainPage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UIMain;
    }
    
    public override void Awake(GameObject go)
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    Debug.Log("当前触摸在UI上");
        //else Debug.Log("当前没有触摸在UI上");
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Skill).onClick.AddListener(() =>
        {
            ShowPage<UISkillPage>();
        });
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Bag).onClick.AddListener(() =>
        {
            ShowPage<UIActerPage>();
            ShowPage<UIKnapsackPage>();
        });
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Acter
).onClick.AddListener(() =>
        {
            ShowPage<UIActerPage>();
            ShowPage<UIKnapsackPage>();
        });
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Setting).onClick.AddListener(() =>
        {
            ShowPage<UISettingPage>();
        });
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Task).onClick.AddListener(() =>
        {
            ShowPage<UISkillPage>();
        });
        Finder.Find<Button>(transform, PathString.UIMain_Btn_Battle).onClick.AddListener(() =>
        {
            ShowPage<UIBattle>();
        });
    }


}
