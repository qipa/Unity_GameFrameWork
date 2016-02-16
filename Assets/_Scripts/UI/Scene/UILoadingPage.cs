using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine.UI;
public class UILoadingPage : TTUIPage
{
    public UILoadingPage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UILoading;
    }

    private Slider progressSlider;
    private Text proValue;

    public override void Awake(GameObject go)
    {
        progressSlider = Finder.Find<Slider>(transform, "ProgressSlider");
        proValue = Finder.Find<Text>(transform, "ProgressText");
        progressSlider.value = 0f;
        progressSlider.enabled = false;
    }

    public override void Refresh()
    {
        CoroutinesManager.CreateTask(LoadingScene(PathString.Scene_Main)).Start();
    }

    public override void Hide()
    {

    }

    private void setProgressValue(int value) {
        progressSlider.value = value / 100f;
        proValue.text = "当前进度为: " + value + "%";
    }
    private IEnumerator LoadingScene(string name) {
        int displayProgress = 0;  
        int toProgress = 0;
        AsyncOperation op = Application.LoadLevelAsync(name);     
        op.allowSceneActivation = false;   
        //while(op.progress < 0.9f) {       
        //    toProgress = (int)op.progress * 100;
        //    while (displayProgress < toProgress)
        //    {
        //        ++displayProgress;
        //        setProgressValue(displayProgress);
        //        yield return new WaitForEndOfFrame();
        //    }
        //}
        toProgress = 100; 
        while(displayProgress < toProgress){        
            ++displayProgress;         
            setProgressValue(displayProgress);     
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
}
