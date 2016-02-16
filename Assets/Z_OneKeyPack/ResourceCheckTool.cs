using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Object = UnityEngine.Object;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;

public class ResourceCheckTool : EditorWindow
{

    [@MenuItem("Tools/资源引用分析工具", false, 3)]
    public static void OpenRes2Check()
    {
        ResourceCheckTool window = (ResourceCheckTool)GetWindow(typeof(ResourceCheckTool), true, "资源引用分析工具");
        window.Show();
    }

    
}
#endif