using UnityEngine;
using System.Collections;
using DG.Tweening;

public enum TweenType
{
    LeanTween,
    DoTween
}
public class TweenTest : MonoBehaviour
{

    public TweenType tweenType;
    void Start()
    {
        if (tweenType == TweenType.DoTween)
        {
            DoTweenTest();
        }
        else
        {
            LeanTweenTest();
        }
    }

    private void LeanTweenTest()
    {
        LeanTween.moveY(this.gameObject, 5f, 1f)
            .setDelay(0.5f)
            .setEase(LeanTweenType.linear)
            .setOnComplete(LeanTweenComplete);
    }

    private void LeanTweenComplete()
    {
        LeanTween.moveY(this.gameObject, 0f, 1f)
            .setDelay(0.5f)
            .setEase(LeanTweenType.linear)
            .setOnComplete(LeanTweenTest);
    }

    private void DoTweenTest()
    {
        DOTween.Init();
        this.transform.DOMoveY(2f, 1f)
            .SetDelay(0.5f)
            .SetEase(Ease.Linear)
            .SetLoops(4, LoopType.Yoyo)
            .SetSpeedBased()
            .OnComplete(MyComplete);
    }

    private void MyComplete()
    {
        //this.transform.DOMoveY(0f, 1f)
        //    .SetDelay(0.5f)
        //    .SetEase(Ease.Linear)
        //    .OnComplete(DoTweenTest);
    }

}
