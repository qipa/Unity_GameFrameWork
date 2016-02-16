using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 加载一条数据
/// </summary>
public class Demo : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = "file:///" + Application.dataPath + "/Config/1.txt";

        IList<WwwLoaderPath> pathList = new List<WwwLoaderPath>();
        pathList.Add(new WwwLoaderPath(filePath, 1, WwwLoaderTypeEnum.TEXT));
        // 这儿可以继续添加，直接所有加载完成

        WwwLoaderManager.instance.Loader(pathList, OnLoaderProgressHandler, OnLoaderCompleteHandler, "txt");
    }

    /// <summary>
    /// 每个对象加载都会调用到
    /// </summary>
    /// <param name="path">Path.</param>
    /// <param name="currentValue">Current value.</param>
    /// <param name="totalValue">Total value.</param>
    private void OnLoaderProgressHandler(string path, float currentValue, float totalValue)
    {

    }

    /// <summary>
    /// 所有资源加载完成调用
    /// </summary>
    private void OnLoaderCompleteHandler()
    {
        string text = WwwDataManager.instance.GetDataText(this.filePath);

        Debug.Log(text);
    }
}