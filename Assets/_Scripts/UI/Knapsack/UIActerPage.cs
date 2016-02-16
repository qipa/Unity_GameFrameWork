using UnityEngine;
using System.Collections;
using TinyTeam.UI;

public class UIActerPage : TTUIPage {

    public UIActerPage()
        : base(UIType.Normal, UIMode.HideOtherAndNeedBack, UICollider.None)
    {
        uiPath = PathString.UIActer;
    }

    public override void Awake(GameObject go)
    { 
    
    }

    public override void Refresh()
    {
        CustomTweenAlpha.GetTween(gameObject).FadeIn(0.5f);
    }

    public override void Hide()
    {
        CustomTweenAlpha alpha = CustomTweenAlpha.GetTween(gameObject);
        alpha.FadeOutTweenFinished += delegate(GameObject go) { this.gameObject.SetActive(false); };
        alpha.FadeOut(0.5f);
    }
}
