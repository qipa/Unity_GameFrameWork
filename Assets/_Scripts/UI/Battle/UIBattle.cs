using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine.UI;

public class UIBattle : TTUIPage {

    public UIBattle() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UIBattle;
    }

    public override void Awake(GameObject go)
    {
        this.transform.Find("Btn_Skill").GetComponent<Button>().onClick.AddListener(OnClickSkillGo);
        this.transform.Find("Btn_Battle").GetComponent<Button>().onClick.AddListener(OnClickGoBattle);
    }

    public override void Refresh()
    {

    }

    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void OnClickSkillGo()
    {
        ShowPage<UISkillPage>();
    }

    private void OnClickGoBattle()
    {
        Debug.Log("should load your battle scene!");
    }
}
