using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Finder
{

    /// <summary>
    /// 查找指定根节点下符合指定的查找器的Transform并保持到findResult中
    /// </summary>
    /// <param name="root"></param>
    /// <param name="findResult"></param>
    /// <param name="finder"></param>
    public static List<Transform> Find(Transform root, IGameObjectFinder finder)
    {
        if (root == null)
            throw new Exception("root can not be null, it defines the starting point of the find path");

        //if (findResult == null)
        //    throw new Exception("findResult can not be null, it used to collect the find result");

        if (finder == null)
            throw new Exception("finder can not be null, it defines how to find transform");
        return finder.Find(root);
    }

    public static List<Transform> Find(Transform root, string name)
    {
        if (root == null)
            throw new Exception("root can not be null, it defines the starting point of the find path");

        if (name == null)
            throw new Exception("name can not be null, it defines how to find transform");
        return new FinderByIteration(new FinderByName(name)).Find(root);
    }

    public static T Find<T>(Transform root, string name)
    {
        if (root == null)
            throw new Exception("root can not be null, it defines the starting point of the find path");
        if (name == null)
            throw new Exception("name can not be null, it defines how to find transform");
        return FinderByComponent.Find<T>(root, name);
    }
}


/// <summary>
/// 根据组件搜索
/// </summary>
/// <typeparam name="T"></typeparam>
public class FinderByComponent
{
    public static T Find<T>(Transform root, string name)
    {
        List<Transform> findResult = new FinderByIteration(new FinderByName(name)).Find(root);
        for (int i = 0; i < findResult.Count; i++)
        {
            if (findResult[i].GetComponent<T>() != null)
                return findResult[i].GetComponent<T>();
        }
        return default(T);
    }
}

/// <summary>
/// 迭代遍历搜索
/// </summary>
public class FinderByIteration : IGameObjectFinder
{
    private IFinderForIteration finderForIteration;
    public FinderByIteration(IFinderForIteration finderForIteration)
    {
        this.finderForIteration = finderForIteration;
    }

    List<Transform> findResult = new List<Transform>();
    public List<Transform> Find(Transform root)
    {
        for (int i = 0, childCount = root.childCount; i < childCount; i++)
        {
            Transform t = root.GetChild(i);
            if (finderForIteration.isVaild(t))
            {
                findResult.Add(t);
            }
            Find(t);
        }
        return findResult;
    }
}


/// <summary>
/// 迭代遍历按名字搜索
/// </summary>
public class FinderByName : IFinderForIteration
{
    protected readonly string NAME;
    public FinderByName(string name)
    {
        NAME = name;
    }

    public bool isVaild(Transform getChild)
    {
        return getChild.gameObject.name.Equals(NAME);
    }
}

/// <summary>
/// 迭代搜索判断
/// </summary>
public interface IFinderForIteration
{
    /// <summary>
    /// 指定节点是否合法
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    bool isVaild(Transform node);
}




/// <summary>
/// 游戏对象搜索接口
/// </summary>
public interface IGameObjectFinder
{
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="root">搜索的开始位置/根节点</param>
    /// <param name="findResult">搜索存放的结果</param>
    List<Transform> Find(Transform root);
}
