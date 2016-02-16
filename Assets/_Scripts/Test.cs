using UnityEngine;
using System.Collections;
using System.Threading;
using System;
using MTools;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
public class Test : MonoBehaviour
{
    public Text text;
    public Slider slider;
    void Awake()
    {
        if (Application.isEditor)
            Debuger.Enable = true;
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            Debuger.Enable = false;
    }
    // Use this for initialization
    void Start()
    {
        Debuger.Log(33);
        Test1();
        Debuger.Log(22);
        text.DOText("10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", 1f);
    }

    //    void ScaleMesh(Mesh mesh,float scale )
    //{
    //var vertices = mesh.vertices;
    //Loom.RunAsync(delegate() {
    //for(var i = 0; i < vertices.Length; i++)
    //{
    //vertices[i] = vertices[i] * scale;
    //}
    //Loom.QueueOnMainThread(function() {
    //mesh.vertices = vertices;
    //mesh.RecalculateBounds();
    //});

    public void Test1()
    {
    //    for (int i = 0; i < 10; i++)
    //    {
    //        AsyncRunner<int>.AsyncRunLock(
    //(AsyncRunner<int>.CallHandler)delegate(object[] p)
    //{
    //    int result = (int)p[0];
    //    Debug.Log("result is " + result.ToString());
    //    return result;
    //},
    //new object[]{1},
    //(AsyncRunner<int>.CallBackHandler)delegate(int result)
    //{
    //    SetSlider(result);
        
    //});
    //    }
        AsyncRunner<int>.AsyncRunLock(Set);
        SetSlider();
    }

    void Set()
    {
        for (int i = 100; i < 2000; i++)
        {
            Debug.Log("result is-------- " + i.ToString());
        }
    }

    void SetSlider()
    {
        for (int i = 0; i < 1000; i++)
        {
            Debug.Log("result is-------- " + i.ToString());
        }
    }

    /// <param name="taskAction">线程任务</param>
    /// <param name="callBackAction">回调方法</param>
    public void NewTask(Action taskAction, Action callBackAction)
    {
        //新建一个WaitCallback委托
        WaitCallback wcb = stat =>
        {
            taskAction();
            Action callback = stat as Action;
            if (callback != null)
            {
                callback();
            }
        };
        //加入线程池,将回调的委托作为参数传入(stat其实就是callbackAction)
        ThreadPool.QueueUserWorkItem(wcb, callBackAction);
    }
}


