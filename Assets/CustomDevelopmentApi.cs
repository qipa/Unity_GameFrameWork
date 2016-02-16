using UnityEngine;
using System.Collections;

public static class CustomDevelopmentApi
{
    /// <summary>
    /// 设置trans的相对坐标
    /// 用法GetComponent<Transform>().SetLocalPos(Vector3.zero);
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public static void SetLocalPos(this Transform trans, float x, float y, float z)
    {
        trans.localPosition = new Vector3(x, y, z);
    }

    public static void SetLocalPos(this Transform trans, Vector3 v3)
    {
        trans.localPosition = v3;
    }

    public static void SetLocalPos(this RectTransform trans, float x, float y, float z)
    {
        trans.localPosition = new Vector3(x, y, z);
    }

    public static void SetLocalPos(this RectTransform trans, Vector3 v3)
    {
        trans.localPosition = v3;
    }

    public static void SetPos(this Transform trans, float x, float y, float z)
    {
        trans.position = new Vector3(x, y, z);
    }

    public static void SetPos(this Transform trans, Vector3 v3)
    {
        trans.position = v3;
    }

    /// <summary>
    /// 判断对象是否存在
    /// 用法GetComponent<RectTransform>().IsNull()
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <returns></returns>
    public static bool IsNull(this RectTransform rectTransform)
    {
        if (rectTransform != null)
        {
            return false;
        }
        else
        {
            Debug.Log("RectTransform null");
            return true;
        }
    }
}
