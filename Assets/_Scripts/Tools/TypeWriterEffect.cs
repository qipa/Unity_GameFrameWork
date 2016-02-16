using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {
    public delegate void MyFunction();
    public int charsPerSecond = 10;
    public bool isActive = false;
    float timer;
    string words;
    Text mText;
    public MyFunction mFunc;

    void Start()
    {
        mText = GetComponent<Text>();
        words = mText.text;
        mText.text = "";
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(1, charsPerSecond);
    }

    void ReloadText()
    {
        mText = GetComponent<Text>();
        words = mText.text;
    }

    public void OnStart()
    {
        ReloadText();
        isActive = true;
    }

    void OnStartEffect()
    {
        if (isActive)
        {
            try
            {
                mText.text = words.Substring(0, (int)(charsPerSecond * timer));
                timer += Time.deltaTime;
            }
            catch 
            {
                OnFinish();
            }
        }
    }

    void OnFinish()
    {
        isActive = false;
        timer = 0;
        GetComponent<Text>().text = words;
        try
        {
            mFunc();
        }
        catch 
        {

        }
    }

    void FixedUpdate()
    {
        OnStartEffect();
    }
}
