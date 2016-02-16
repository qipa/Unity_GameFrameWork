using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine.UI;

public class UIKnapsackPage : TTUIPage
{
    public UIKnapsackPage()
        : base(UIType.Normal, UIMode.HideOtherAndNeedBack, UICollider.None)
    {
        uiPath = PathString.UIKnapsack;
    }

    private int m_PageShowNum = 20;
    private int m_PageIndex = 1;
    private int m_PageCount = 0;
    private int m_ItemsCount = 0;
    private List<UIKnapsackItem> m_ItemsList;
    private Button m_BtnPrevious;
    private Button m_BtnNext;
    private Text m_PanelText;
    private Transform m_PanelTransform;

    public override void Awake(GameObject go)
    {
        m_BtnPrevious = Finder.Find<Button>(transform, "Btn_Previous");
        m_BtnNext = Finder.Find<Button>(transform, "Btn_Next");
        m_PanelText = Finder.Find<Text>(transform, "PageNum");
        m_PanelTransform = Finder.Find(transform, "Content")[0];
        m_BtnPrevious.onClick.AddListener(Previous);
        m_BtnNext.onClick.AddListener(Next);
        InitItems();
    }

    public override void Refresh()
    {
        BindPage(m_PageIndex);
        RefreshPageNum();
        CustomTweenAlpha.GetTween(gameObject).FadeIn(0.5f);
    }

    public override void Hide()
    {
        m_PageIndex = 1;
        CustomTweenAlpha alpha = CustomTweenAlpha.GetTween(gameObject);
        alpha.FadeOutTweenFinished += delegate(GameObject go) { this.gameObject.SetActive(false); };
        alpha.FadeOut(0.5f);
    }

    private void InitItems()
    {
        UIKnapsackItem[] items = new UIKnapsackItem[]
        {
            new UIKnapsackItem("bluePotion01","bluePotion01"),
            new UIKnapsackItem("bluePotion02","bluePotion02"),
            new UIKnapsackItem("boot01","boot01"),
            new UIKnapsackItem("boot02","boot02"),
            new UIKnapsackItem("cloth01","cloth01"),
            new UIKnapsackItem("cloth02","cloth02"),
            new UIKnapsackItem("hat01","hat01"),
            new UIKnapsackItem("hat02","hat02"),
            new UIKnapsackItem("redPotion01","redPotion01"),
            new UIKnapsackItem("redPotion02","redPotion02"),
            new UIKnapsackItem("trousers01","trousers01"),
            new UIKnapsackItem("trousers02","trousers02"),
            new UIKnapsackItem("weapon01","weapon01"),
            new UIKnapsackItem("weapon02","weapon02")
        };

        m_ItemsList = new List<UIKnapsackItem>();
        for (int i = 0; i < Random.Range(1, 1000); i++)
            m_ItemsList.Add(items[Random.Range(0, items.Length)]);
        m_ItemsCount = m_ItemsList.Count;
        m_PageCount = (m_ItemsCount % 20) == 0 ? m_ItemsCount / 20 : (m_ItemsCount / 20 + 1);
        BindPage(m_PageIndex);
        RefreshPageNum();
    }

    private void RefreshPageNum()
    {
        m_PanelText.text = string.Format("{0}/{1}", m_PageIndex.ToString(), m_PageCount.ToString());
    }

    public void Next()
    {
        if (m_PageCount <= 0)
            return;
        if (m_PageIndex >= m_PageCount)
            return;
        m_PageIndex += 1;
        if (m_PageIndex >= m_PageCount)
            m_PageIndex = m_PageCount;
        BindPage(m_PageIndex);
        RefreshPageNum();
    }

    public void Previous()
    {
        if (m_PageCount <= 0)
            return;
        if (m_PageIndex <= 1)
            return;
        m_PageIndex -= 1;
        if (m_PageIndex < 1)
            m_PageIndex = 1;
        BindPage(m_PageIndex);
        RefreshPageNum();
    }

    private void BindPage(int index)
    {
        //Debug.Log(m_ItemsList.Count + "   " + m_ItemsCount + "  " + index);
        if (m_ItemsList == null || m_ItemsCount <= 0)
            return;
        if (index < 0 || index > m_ItemsCount)
            return;

        if (m_PageCount == 1)
        {
            for (int i = 0; i < m_PageShowNum; i++)
            {
                if (i < m_ItemsCount)
                    BindGridItem(m_PanelTransform.GetChild(i), m_ItemsList[i]);
                else
                    SetObjActiveFalse(m_PanelTransform.GetChild(i));
            }
        }
        else if (m_PageCount > 1)
        {
            if (index == m_PageCount)
            {
                int lastPageItemNum = m_ItemsCount - m_PageShowNum * (index - 1);
                for (int i = 0; i < m_PageShowNum; i++)
                {
                    if (i < lastPageItemNum)
                        BindGridItem(m_PanelTransform.GetChild(i), m_ItemsList[m_PageShowNum * (index - 1) + i]);
                    else
                        SetObjActiveFalse(m_PanelTransform.GetChild(i));
                }
            }
            else
            {
                for (int i = 0; i < m_PageShowNum; i++)
                    BindGridItem(m_PanelTransform.GetChild(i), m_ItemsList[m_PageShowNum * (index - 1) + i]);
            }
        }
    }

    private void SetObjActiveFalse(Transform trans)
    {
        trans.gameObject.SetActive(false);
    }

    private void BindGridItem(Transform trans, UIKnapsackItem gridItem)
    {
        Finder.Find<Image>(trans, "Image").sprite = LoadSprite(gridItem.ItemSprite);
        Text text = Finder.Find<Text>(trans, "title");
        text.text = gridItem.ItemName;
        text.fontSize = 17;
        Button btn = Finder.Find<Button>(trans, "Image");
        btn.onClick.AddListener(() => { Debug.Log("当前点击的元素名称为:" + gridItem.ItemName); });
        trans.gameObject.SetActive(true);
    }

    private Sprite LoadSprite(string assetName)
    {
        Texture texture = (Texture)Resources.Load("Item/" + assetName);
        Sprite sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
