using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

public class OneKeyPacker : EditorWindow
{

    /// <summary>
    /// 创建、显示窗体
    /// </summary>
    [@MenuItem("Tools/一键打包工具", false, 2)]
    private static void Init()
    {
        OneKeyPacker window = (OneKeyPacker)GetWindow(typeof(OneKeyPacker), true, "一键打包工具");
        window.Show();
    }
    private int[] IntArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private int BuildTargetInt = 0;
    private string[] BuildTargetString = new string[] { "Android", "iPhone", "Win Phone8", "WebGL" };

    private int AndroidChannelInt = 0;
    private string[] AndroidChannelString = new string[] { "360", "UC", "QQ" };

    private int IosChannelInt = 0;
    private string[] IosChannelString = new string[] { "App Store" };

    private string bundleIdentifier = "com.game.";
    private string version = "1.0";
    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        BuildTargetInt = EditorGUILayout.IntPopup("平台", BuildTargetInt, BuildTargetString, IntArray);
        if (BuildTargetInt == 0)
        {
            AndroidChannelInt = EditorGUILayout.IntPopup("Android渠道", AndroidChannelInt, AndroidChannelString, IntArray);
        }
        else if (BuildTargetInt == 1)
        {
            IosChannelInt = EditorGUILayout.IntPopup("Ios渠道", IosChannelInt, IosChannelString, IntArray);
        }

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Bundle Identifier", GUILayout.Width(145f));
        bundleIdentifier = EditorGUILayout.TextField(bundleIdentifier);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Version", GUILayout.Width(145f));
        version = EditorGUILayout.TextField(version);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("打包"))
        {
            EditorApplication.delayCall += OneKeyPack;
            Close();
        }
    }


    void OneKeyPack()
    {
        //AssetDatabase.CopyAsset("path", "newPath");
        BulidTarget();
    }

    //得到工程中所有场景名称
    private string[] SCENES;
    string target_dir;
    string target_name;
    BuildTargetGroup targetGroup = BuildTargetGroup.Unknown;
    BuildTarget buildTarget;

    void BulidTarget()
    {
        SCENES = FindEnabledEditorScenes();
        string applicationPath = Application.dataPath.Replace("/Assets", "");

        PlayerSettings.bundleIdentifier = bundleIdentifier;
        PlayerSettings.bundleVersion = version;


        if (BuildTargetInt == 0)
        {
            target_dir = applicationPath + "/TargetAndroid";
            target_name = AndroidChannelString[AndroidChannelInt] + ".apk";
            targetGroup = BuildTargetGroup.Android;
            buildTarget = BuildTarget.Android;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, AndroidChannelString[AndroidChannelInt]);
        }
        if (BuildTargetInt == 1)
        {
            target_dir = applicationPath + "/TargetIOS";
            target_name = IosChannelString[IosChannelInt] + ".ipa";
            targetGroup = BuildTargetGroup.iOS;
            buildTarget = BuildTarget.iOS;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, IosChannelString[IosChannelInt]);
        }

        //每次build删除之前的残留
        if (Directory.Exists(target_dir))
        {
            if (File.Exists(target_name))
            {
                File.Delete(target_name);
            }
        }
        else
        {
            Directory.CreateDirectory(target_dir);
        }


        if (targetGroup != BuildTargetGroup.Unknown)
        {
            //开始Build场景，等待吧～
            GenericBuild(SCENES, target_dir + "/" + target_name, buildTarget, BuildOptions.None);
        }

    }

    string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

    void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
        string res = BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
        if (res.Length > 0)
        {
            throw new Exception("BuildPlayer failure: " + res);
        }
    }
}
#endif