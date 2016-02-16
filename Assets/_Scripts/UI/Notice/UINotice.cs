using UnityEngine;
using System.Collections;
using TinyTeam.UI;
using UnityEngine.UI;

public class UINotice : TTUIPage
{
    public UINotice() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = PathString.Notice;
    }

    public override void Awake(GameObject go)
    {
        this.gameObject.transform.Find("Animator/Btn_Confim").GetComponent<Button>().onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public override void Refresh()
    {

    }

    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
