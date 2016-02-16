using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;   
public class UIFirstAnima : MonoBehaviour {

    private Tweener m_pos;
    private Tweener m_rota;
    private Tweener m_scale;
    private Tweener m_color;
    void Start()
    {
        // 全局初始化  
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);
        Image image = transform.GetComponent<Image>();
        // 位置  
        m_pos = image.rectTransform.DOMove(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), 1f);
        m_pos.SetEase(Ease.OutCubic);
        m_pos.SetLoops(10, LoopType.Yoyo);
        // 旋转  
        m_rota = image.rectTransform.DORotate(new Vector3(0, 180, 0), 1);
        m_rota.SetEase(Ease.Linear);
        m_rota.SetLoops(10, LoopType.Yoyo);
        // 缩放  
        m_scale = image.rectTransform.DOScale(new Vector3(0.6f, 0.6f, 1f), 1);
        m_scale.SetEase(Ease.Linear);
        m_scale.SetLoops(10, LoopType.Yoyo);
        // 颜色  
        m_color = image.material.DOColor(new Color(0f, 1f, 1f, 0.7f), 1f);
        m_color.SetEase(Ease.Linear);
        m_color.SetLoops(10, LoopType.Yoyo);
        // 注册开始和结束事件  
        m_pos.OnStart(AnimaStart);
        m_pos.OnComplete(AnimaEnd);
    }
    private void AnimaStart()
    {
        Debug.Log("动画开始");
    }
    private void AnimaEnd()
    {
        Debug.Log("动画结束");
    }  
}
