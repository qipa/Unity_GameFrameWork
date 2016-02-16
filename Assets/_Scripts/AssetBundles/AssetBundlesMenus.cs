using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class AssetBundlesMenus {

    [MenuItem("Assets/AssetBundles/Build AssetBundles")]
    static public void BuildAssetBundles()
    {
        BuildScript.BuildAssetBundles();
    }

    const string kSimulationMode = "Assets/AssetBundles/Simulation Mode";

    [MenuItem(kSimulationMode)]
    public static void ToggleSimulationMode()
    {
        AssetBundleManager.SimulateAssetBundleInEditor = !AssetBundleManager.SimulateAssetBundleInEditor;
    }

    [MenuItem(kSimulationMode, true)]
    public static bool ToggleSimulationModeValidate()
    {
        Menu.SetChecked(kSimulationMode, AssetBundleManager.SimulateAssetBundleInEditor);
        return true;
    }

    [MenuItem("Assets/AssetBundles/SetAssetBundleName")]
    static void SetBundleName()
    {
        UnityEngine.Object[] selects = Selection.objects;
        foreach (UnityEngine.Object selected in selects)
        {
            string path = AssetDatabase.GetAssetPath(selected);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            asset.assetBundleName = selected.name; 
            asset.assetBundleVariant = "unity3d";
            asset.SaveAndReimport();
        }
        AssetDatabase.Refresh();
    }

    [MenuItem("Assets/AssetBundles/CancelAssetBundleName")]
    static void CancelBundleName()
    {
        UnityEngine.Object[] selects = Selection.objects;
        foreach (UnityEngine.Object selected in selects)
        {
            string path = AssetDatabase.GetAssetPath(selected);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            if (!string.IsNullOrEmpty(asset.assetBundleName))
                asset.assetBundleName = string.Empty;
            if (!string.IsNullOrEmpty(asset.assetBundleVariant))
                asset.assetBundleVariant = string.Empty;
            asset.SaveAndReimport();
        }
        AssetDatabase.Refresh();
    }
}
#endif