using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomEditor(typeof(PatrolNPC))]
public class PatrolPathEditor : Editor
{

    private Vector3[] paths;

    /// <summary>
    /// 显示寻路信息的GUI
    /// </summary>
    private GUIStyle style = new GUIStyle();

    /// <summary>
    /// 初始化
    /// </summary>
    //void OnEnable()
    //{
    //    //获取当前NPC的寻路路径
    //    paths = ((PatrolNPC)target).Paths;
    //    //初始化GUIStyle
    //    style.fontStyle = FontStyle.Normal;
    //    style.fontSize = 15;
    //}


    //void OnSceneGUI()
    //{
    //    //获取当前NPC的寻路路径
    //    paths = ((PatrolNPC)serializedObject.targetObject).Paths;
    //    //设置节点的颜色为红色
    //    Handles.color = Color.red;
    //    if (paths.Length <= 0 || paths.Length < 2) return;
    //    //在场景中绘制每一个寻路节点
    //    //可以在场景中编辑节点并将更新至对应的NPC
    //    for (int i = 0; i < paths.Length; i++)
    //    {
    //        paths = Handles.PositionHandle(paths, Quaternion.identity);
    //        Handles.SphereCap(i, paths, Quaternion.identity, 0.25f);
    //        Handles.Label(paths, "PathPoint" + i, style);
    //        if (i < paths.Length && i + 1 < paths.Length)
    //        {
    //            Handles.DrawLine(paths, paths[i + 1]);
    //        }
    //    }
    //}

}