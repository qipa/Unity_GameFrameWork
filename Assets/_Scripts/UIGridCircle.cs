using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 自动按环形排列数据
public class UIGridCircle : MonoBehaviour
{

    public float m_radius = 252f;
    public int m_activeChildCount = 0;
    private List<Transform> m_childList = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        InitChildTrans();
        Reset();
    }

    [ContextMenu("Reposition")]
    void Reposition()
    {
        InitChildTrans();

        if (m_activeChildCount <= 1) return;

        // 角度
        float angleUnit = Mathf.PI / (2 * (m_activeChildCount - 1));
        for (int i = 0; i < m_activeChildCount; i++)
        {
            Transform childTrans = m_childList[i];
            childTrans.localPosition = GetChildPos(i);
            //float angle = angleUnit * i;
            //float x = Mathf.Cos(angle) * m_radius;
            //float y = Mathf.Sin(angle) * m_radius;
            //childTrans.localPosition = new Vector3(x, y, 0);
            //Debug.Log(string.Format("angle:{2} ({0}, {1})", x, y, angle * 180 / Mathf.PI));
        }
        //Debug.Log(Mathf.Cos(0) + " " + Mathf.Sin(Mathf.PI / 2));
    }

    public void InitChildTrans()
    {
        m_childList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                m_childList.Add(transform.GetChild(i));
        }
        m_activeChildCount = m_childList.Count;
    }

    public Transform GetActiveChildByIndex(int index)
    {
        if (m_childList.Count >= index + 1) return m_childList[index];
        return null;
    }

    public Vector3 GetChildPos(int i)
    {
        float angleUnit = (Mathf.PI) / (2 * (m_activeChildCount - 1));
        float angle = angleUnit * (m_activeChildCount + i - 1);
        float x = Mathf.Cos(angle) * m_radius;
        float y = Mathf.Sin(angle) * m_radius;
        return new Vector3(x, y, 0);
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localPosition = Vector3.zero;
    }

}
