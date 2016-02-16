using UnityEngine;
using System.Collections;
using System.Runtime.Hosting;

public class Instance : MonoBehaviour
{
    //[RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        GameObject.DontDestroyOnLoad(new GameObject("Instance", typeof(Instance))
        {
            hideFlags = HideFlags.HideInHierarchy
        });
        Debug.Log("RuntimeInitializeOnLoadMethod");
    }
}