using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CustomTweener : MonoBehaviour
{
    public enum DoTweenType
    {
        None,
        DOMove,
        DORotate,
        DOScale,
        DOColor
    }

    public DoTweenType doTweenType = DoTweenType.None;
    public Vector3 endVector3;
    public Color endColor;
    public float duration;
    public Ease easeType = Ease.Linear;

    public int loops;
    public LoopType loopType = LoopType.Yoyo;
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);
    }

    public void DOAnchorPos(Transform tran)
    {
        tran.GetComponent<RectTransform>().DOAnchorPos(endVector3, duration)
            .SetEase(easeType)
            .SetLoops(loops, loopType);
    }

    public void DOMove(Transform tran)
    {
        tran.GetComponent<RectTransform>().DOMove(endVector3, duration)
            .SetEase(easeType)
            .SetLoops(loops, loopType);
    }

    public void DORotate(Transform tran)
    {
        tran.GetComponent<RectTransform>().DORotate(endVector3, duration)
            .SetEase(easeType)
            .SetLoops(loops, loopType);
    }

    public void DOScale(Transform tran)
    {
        tran.GetComponent<RectTransform>().DOScale(endVector3, duration)
            .SetEase(easeType)
            .SetLoops(loops, loopType);
    }

    public void DOColor(Transform tran)
    {
        tran.GetComponent<Image>().DOColor(endColor, duration)
            .SetEase(easeType)
            .SetLoops(loops, loopType);
    }
}
