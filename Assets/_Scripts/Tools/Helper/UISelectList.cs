using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UISelectList : MonoBehaviour
{

    public UISelectListType m_type = UISelectListType.Down;
    public enum UISelectListType
    {
        Up,
        Down
    }
    public Text m_curText;
    public GameObject m_listPanel;
    public RectTransform m_listBg;
    public float m_listBgOffset = 4;

    public Transform m_parent;
    public GameObject m_item;
    public int m_itemHeight = 20;
    public Transform m_foucs;

    private int m_curIndex = 0;
    private List<string> m_list = new List<string>();

    //void Start()
    //{
    //    m_item.SetActive(false);
    //    Hide();
    //    UIEventListener.Get(m_curText.gameObject).onClick = OnClickBtn;
    //    UIEventListener.Get(m_listPanel).onHover = OnHoverPanel;
    //    // 测试一下  
    //    Test();
    //}

    //void Test()
    //{
    //    m_list = new List<string>();
    //    m_list.Add("1111111");
    //    m_list.Add("2222222");
    //    m_list.Add("3333333");
    //    m_list.Add("4444444");
    //    m_list.Add("5555555");
    //    m_list.Add("6666666");
    //    SetList(m_list);
    //}

    //public void Show()
    //{
    //    m_listPanel.SetActive(true);
    //}

    //public void Hide()
    //{
    //    m_listPanel.SetActive(false);
    //}

    //public void SetText(int index)
    //{
    //    m_curIndex = index;
    //    m_curText.text = m_list[index];
    //}

    //public int GetIndex()
    //{
    //    return m_curIndex;
    //}

    //public List<string> SetList(List<string> list)
    //{
    //    // 返回item对象列表，给逻辑注册事件等  
    //    List<string> itemList = new List<string>();
    //    m_list = list;
    //    int num = list.Count;
    //    for (int i = 0; i < num; i++)
    //    {
    //        Transform item = m_parent.FindChild(i.ToString());
    //        if (item == null)
    //        {
    //            item = ((GameObject)GameObject.Instantiate(m_item)).transform;
    //            item.SetParent(m_parent.transform);
    //            item.name = i.ToString();
    //            item.localScale = Vector3.one;
    //            item.gameObject.SetActive(true);
    //        }
    //        item.GetComponent<Text>().text = list[i];
    //        if (m_type == UISelectListType.Down)
    //            item.localPosition = new Vector2(0, -1 * i * m_itemHeight);
    //        else
    //            item.localPosition = new Vector2(0, i * m_itemHeight);

    //        UIEventListener lis = UIEventListener.Get(item.gameObject);
    //        lis.onHover = OnHoverItem;
    //        lis.onClick = OnClickItem;
    //        lis.parameter = i;
    //        itemList.Add(item.gameObject);
    //    }
    //    // 更新背景大小  
    //    m_listBg.sizeDelta = new Vector2(m_listBg.sizeDelta.x, num * m_itemHeight + 2 * m_listBgOffset);
    //    // 更新列表位置和背景位置  
    //    if (m_type == UISelectListType.Down)
    //    {
    //        m_listPanel.transform.localPosition = new Vector2(0, -1 * GetComponent().sizeDelta.y);
    //        m_listBg.pivot = new Vector2(0.5f, 1f);
    //        m_listBg.localPosition = new Vector3(0, m_listBgOffset + m_itemHeight * 0.5f, 0);
    //    }
    //    else
    //    {
    //        m_listPanel.transform.localPosition = new Vector2(0, GetComponent().sizeDelta.y);
    //        m_listBg.pivot = new Vector2(0.5f, 0f);
    //        m_listBg.localPosition = new Vector3(0, -1 * m_listBgOffset - m_itemHeight * 0.5f, 0);
    //    }
    //    return itemList;
    //}

    //private void OnClickBtn(GameObject go)
    //{
    //    if (m_listPanel.activeSelf)
    //        Hide();
    //    else
    //        Show();
    //}

    //private void OnHoverItem(GameObject go, bool isHover)
    //{
    //    if (isHover)
    //        m_foucs.localPosition = go.transform.localPosition;
    //}

    //private void OnClickItem(GameObject go)
    //{
    //    int index = (int)UIEventListener.Get(go).parameter;
    //    SetText(index);
    //    Hide();
    //}

    //private void OnHoverPanel(GameObject go, bool isHover)
    //{
    //    if (!isHover)
    //        Hide();
    //}  
}
