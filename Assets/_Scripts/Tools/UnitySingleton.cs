using UnityEngine;
using System.Collections;

public class UnitySingleton<T> : MonoBehaviour
    where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    //obj.hideFlags = HideFlags.HideAndDontSave;//隐藏实例化的new game object，下同
                    _instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _instance;
        }
    }

    //该函数用来初始化一些数据
    public virtual void Init() { }

    //确保在程序退出时销毁实例。
    private void OnApplicationQuit()
    {
        _instance = null;
    }
}
