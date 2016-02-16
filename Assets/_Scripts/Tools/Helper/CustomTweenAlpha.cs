using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CustomTweenAlpha : MonoBehaviour
{

    public delegate void TweenEvent(GameObject go);

    public event TweenEvent FadeOutTweenStart;

    public event TweenEvent FadeOutTweenFinished;

    public event TweenEvent FadeInTweenStart;

    public event TweenEvent FadeInTweenFinished;

    public static CustomTweenAlpha GetTween(GameObject gb)
    {
        CustomTweenAlpha player = gb.GetComponent<CustomTweenAlpha>();
        if (player == null)
            player = gb.AddComponent<CustomTweenAlpha>();
        return player;
    }

    /// <summary>
    /// 淡入
    /// </summary>
    /// <param name="time"></param>
    public void FadeIn(float fadetime)
    {
        StopAllCoroutines();
        StartCoroutine(Fade(fadetime, 0));
    }

    /// <summary>
    /// 淡出
    /// </summary>
    /// <param name="time"></param>
    public void FadeOut(float fadetime)
    {
        StopAllCoroutines();
        StartCoroutine(Fade(fadetime, 1));
    }

    private IEnumerator Fade(float fadeTime, float toValue)
    {
        StartTween(toValue);
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float percentage = Mathf.Clamp01(elapsedTime / fadeTime);
            SetAlpha(percentage, toValue);
            yield return null;
        }
        FinishTween(toValue);
    }

    private void StartTween(float toValue)
    {
        if (toValue == 1)
        {
            if (FadeOutTweenStart != null)
                FadeOutTweenStart(this.gameObject);
        }
        else
        {
            if (FadeInTweenStart != null)
                FadeInTweenStart(this.gameObject);
        }
    }

    private void FinishTween(float toValue)
    {
        if (toValue == 1)
        {
            if (FadeOutTweenFinished != null)
                FadeOutTweenFinished(this.gameObject);
        }
        else
        {
            if (FadeInTweenFinished != null)
                FadeInTweenFinished(this.gameObject);
        }
    }

    private void SetAlpha(float percentage, float toValue)
    {
        float alpha = Mathf.Abs(percentage - toValue);
        Component[] components = this.gameObject.GetComponentsInChildren<Component>();
        foreach (Component c in components)
        {
            SetAlphaByType(c, alpha);
        }
    }

    private void SetAlphaByType(Component c, float alpha)
    {
        switch (c.GetType().ToString())
        {
            case "UnityEngine.CanvasRenderer":
                (c as CanvasRenderer).SetAlpha(alpha);
                break;
            case "UnityEngine.UI.Image":
                UnityEngine.UI.Image image = (c as UnityEngine.UI.Image);
                image.color = new Color
                (
                image.color.r,
                image.color.g,
                image.color.b,
                alpha
                );
                break;
        }
    }
}
