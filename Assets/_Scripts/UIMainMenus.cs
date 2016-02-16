using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIMainMenus : MonoBehaviour {

    public UIGridCircle m_cirle;
    public float m_animTime = 0.08f;
    public bool m_show = false;
    private float m_timeClicked = 0f;

    void Start()
    {
        m_show = false;
    }

    [ContextMenu("MainMenuOnClick")]
    public void MainMenuOnClick()
    {
        m_cirle.InitChildTrans();

        if (Time.realtimeSinceStartup - m_timeClicked < m_animTime * m_cirle.m_activeChildCount) return;
        m_timeClicked = Time.realtimeSinceStartup;

        if (!m_show)
        {
            m_show = true;
            StartCoroutine(IEMoveAnim(true));
        }
        else
        {
            m_show = false;
            StartCoroutine(IEMoveAnim(false));
        }
    }

    IEnumerator IEMoveAnim(bool show)
    {
        for (int i = 0; i < m_cirle.m_activeChildCount; i++)
        {
            Vector3 pos = m_cirle.GetChildPos(m_cirle.m_activeChildCount - 1 - i);
            Transform ts = m_cirle.GetActiveChildByIndex(i);
            RectTransform rf = ts as RectTransform;
            rf.DOLocalMove(show ? pos : Vector3.zero, m_animTime);
            yield return new WaitForSeconds(m_animTime);
        }
    }
}
