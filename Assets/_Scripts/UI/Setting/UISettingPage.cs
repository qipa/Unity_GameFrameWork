using UnityEngine;
using System.Collections;
using TinyTeam.UI;
using UnityEngine.UI;
public class UISettingPage : TTUIPage {

    public UISettingPage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = PathString.UISetting;
    }

    private Toggle MusicToggle;
    private Toggle SoundToggle;
    private Slider SoundSlider;
    private Slider MusicSlider;

    public override void Awake(GameObject go)
    {
        MusicToggle = Finder.Find<Toggle>(transform, "MusicToggle");
        SoundToggle = Finder.Find<Toggle>(transform, "SoundToggle");
        SoundSlider = Finder.Find<Slider>(transform, "SoundSlider");
        MusicSlider = Finder.Find<Slider>(transform, "MusicSlider");
        MusicToggle.onValueChanged.AddListener(SetMusicToggle);
        SoundToggle.onValueChanged.AddListener(SetSoundToggle);
        SoundSlider.onValueChanged.AddListener(SetSoundSlider);
        MusicSlider.onValueChanged.AddListener(SetMusicSlider);
    }

    public override void Refresh()
    {

    }

    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void SetMusicSlider(float value)
    {
        MusicSlider.value = value;
    }

    private void SetSoundSlider(float value)
    {
        SoundSlider.value = value;
    }

    private void SetMusicToggle(bool isOpen)
    {
        
    }

    private void SetSoundToggle(bool isOpen)
    {

    }
}
