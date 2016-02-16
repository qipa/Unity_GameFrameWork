using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class TabControlEntry
{
    [SerializeField]
    private GameObject panel = null;
    public GameObject Panel { get { return panel; } }

    [SerializeField]
    private Button tab = null;
    public Button Tab { get { return tab; } }

    public TabControlEntry(Button btn, GameObject go)
    {
        tab = btn;
        panel = go;
    }
}

public class TabControl : MonoBehaviour
{
    [SerializeField]
    private List<TabControlEntry> entries = new List<TabControlEntry>();

    [SerializeField]
    private GameObject panelContainer = null;
    [SerializeField]
    private GameObject tabContainer = null;

    [SerializeField]
    private GameObject tabPrefab = null;
    [SerializeField]
    private GameObject panelPrefab = null;

    protected virtual void Start()
    {
        int tabCount = tabContainer.transform.childCount;
        int panelCount = panelContainer.transform.childCount;
        if (tabCount == panelCount)
        {
            entries.Clear();
            for (int i = 0; i < tabCount; i++)
            {
                entries.Add(new TabControlEntry(tabContainer.transform.GetChild(i).GetComponent<Button>(), panelContainer.transform.GetChild(i).gameObject));
            }
        }
        else
        {
            Debug.Log("Tab和Panel的数量不一致，请核对");
            return;
        }
        foreach (TabControlEntry entry in entries)
            AddButtonListener(entry);

        if (entries.Count > 0)
            SelectTab(entries[0]);
    }

    public void RemoveNullEntry()
    {
        entries.RemoveAll(new Predicate<TabControlEntry>(IsNull));
    }

    public void AddEntry(TabControlEntry entry)
    {
        entries.Add(entry);
    }

    static bool IsNull(TabControlEntry str)
    {
        if (str.Panel == null || str.Tab == null)
            return true;
        return false;
    }

    private void AddButtonListener(TabControlEntry entry)
    {
        entry.Tab.onClick.AddListener(() => SelectTab(entry));
    }

    private void SelectTab(TabControlEntry selectedEntry)
    {
        foreach (TabControlEntry entry in entries)
        {
            bool isSelected = entry == selectedEntry;
            entry.Tab.interactable = !isSelected;
            entry.Panel.SetActive(isSelected);
        }
    }
}
