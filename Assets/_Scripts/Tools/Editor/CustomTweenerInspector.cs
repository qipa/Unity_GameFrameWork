using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CustomTweener))]
public class CustomTweenerInspector : Editor
{
    private SerializedObject customTweener;
    private SerializedProperty doType, endVector3, endColor, duration, easeType, loops, loopType;

    void OnEnable()
    {
        customTweener = new SerializedObject(target);
        doType = customTweener.FindProperty("doTweenType");
        endVector3 = customTweener.FindProperty("endVector3");
        endColor = customTweener.FindProperty("endColor");

        duration = customTweener.FindProperty("duration");
        easeType = customTweener.FindProperty("easeType");
        loops = customTweener.FindProperty("loops");
        loopType = customTweener.FindProperty("loopType");
    }

    // 重写Inspector检视面板
    public override void OnInspectorGUI()
    {
        customTweener.Update();

        EditorGUILayout.PropertyField(doType);
        if (doType.enumValueIndex != 0)
        {
            if (doType.enumValueIndex == 4)
                EditorGUILayout.PropertyField(endColor);
            else
                EditorGUILayout.PropertyField(endVector3);
            EditorGUILayout.PropertyField(duration);
            EditorGUILayout.PropertyField(easeType);
            EditorGUILayout.PropertyField(loops);
            EditorGUILayout.PropertyField(loopType);
        }
        customTweener.ApplyModifiedProperties();
    }
}
