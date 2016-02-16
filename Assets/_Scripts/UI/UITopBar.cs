using UnityEngine;
using System.Collections;
using TinyTeam.UI;
using UnityEngine.UI;

public class UITopBar : TTUIPage
{

    public UITopBar()
        : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = PathString.Topbar;
    }

    private Button Btn_Back;
    private Button Btn_Notice;

    public override void Awake(GameObject go)
    {
        Handheld.Vibrate();
        Btn_Back = Finder.Find<Button>(transform, "btn_back");
        Btn_Notice = Finder.Find<Button>(transform, "btn_notice");
        Btn_Back.onClick.AddListener(() => { TTUIPage.ClosePage(); });
        Btn_Notice.onClick.AddListener(() => { ShowPage<UINotice>(); });
    }


}
