using UnityEngine;
using System.Collections;
using TinyTeam.UI;
using UnityEngine.UI;
public class UIAnnouncementPage : TTUIPage
{

    public UIAnnouncementPage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UIAnnouncement;
    }

    private Text AnnouncementText;

    public override void Awake(GameObject go)
    {
        AnnouncementText = Finder.Find<Text>(transform, "Text");
    }

    public override void Refresh()
    {
        AnnouncementText.text = PathString.AnnouncementText;
    }

    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
