using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR
public class TextureImporterManager : EditorWindow
{
    /// <summary>
    /// 创建、显示窗体
    /// </summary>
    [@MenuItem("Tools/图片批量处理工具")]
    private static void Init()
    {
        TextureImporterManager window = (TextureImporterManager)GetWindow(typeof(TextureImporterManager), true, "图片批量处理工具");
        window.Show();
    }

    /// <summary>
    /// 临时存储int[]
    /// </summary>
    private int[] IntArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private int TextureTypeInt = 0;
    private string[] TextureTypeString = new string[] { "Texture", "Normal Map", "Editor GUI", "Sprite(2D and UI)", "Cursor", "Cubemap", "Cookie", "Lightmap", "Advanced" };
    private int SpriteModeInt = 0;
    private string[] SpriteModeString = new string[] { "Single", "Multiple" };
    private string PackingTag = string.Empty;
    private int PixelsPerUnit;
    public int PivotInt = 0;
    private string[] PivotString = new string[] { "Center", "Top Left", "Top", "Top Right", "Left", "Right", "Bottom Left", "Bottom", "Bottom Right", "Custom" };
    public bool GenerateMipMaps = false;
    public bool ReadOrWriteEnabled = false;
    private string[] boolString = new string[] { "Bool", "True"};
    private int FilterModeInt = 0;
    private string[] FilterModeString = new string[] { "Point", "Bilinear", "Trilinear" };

    private int WrapModeInt = 0;
    private string[] WrapModeString = new string[] { "Repeat", "Clamp" };


    private int MaxSizeInt = 4;
    private string[] MaxSizeString = new string[] { "32", "64", "128", "256", "512", "1024", "2048", "4096" };
    private int FormatInt = 0;
    private string[] FormatString = new string[] { "Compressed", "16 bits", "True Color", "Crunched" };

    private int CompressionQualityInt = 1;
    private string[] CompressionQualityString = new string[] { "Fast", "Normal", "Best" };

    private int BuildTargetInt = 1;
    private string[] BuildTargetString = new string[] { "Default", "Web", "Standalone", "iPhone", "Android", "Win8", "WebGL" };


    private void OnGUI()
    {
        //Texture Type
        TextureTypeInt = EditorGUILayout.IntPopup("Texture Type", TextureTypeInt, TextureTypeString, IntArray);
        if (TextureTypeInt == 0)//Texture
        {
            WrapModeInt = EditorGUILayout.IntPopup("  Wrap Mode", WrapModeInt, WrapModeString, IntArray);
        }
        else if (TextureTypeInt == 3)//Sprite(2D and UI)
        {
            //SpriteModeInt = EditorGUILayout.IntPopup("  Sprite Mode", SpriteModeInt, SpriteModeString, IntArray);
            GenerateMipMaps = EditorGUILayout.Toggle("  Generate Mip Maps", GenerateMipMaps);
        }
        else if (TextureTypeInt == 8)//Advanced
        {
            WrapModeInt = EditorGUILayout.IntPopup("  Wrap Mode", WrapModeInt, WrapModeString, IntArray);
            GenerateMipMaps = EditorGUILayout.Toggle("  Generate Mip Maps", GenerateMipMaps);
            ReadOrWriteEnabled = EditorGUILayout.Toggle("  Read/Write Enabled", ReadOrWriteEnabled);
        }

        FilterModeInt = EditorGUILayout.IntPopup("  Filter Mode", FilterModeInt, FilterModeString, IntArray);

        //BuildTargetInt = EditorGUILayout.IntPopup("Platform", BuildTargetInt, BuildTargetString, IntArray);

        MaxSizeInt = EditorGUILayout.IntPopup("  Max Size", MaxSizeInt, MaxSizeString, IntArray);
        //FormatInt = EditorGUILayout.IntPopup("  Format", FormatInt, FormatString, IntArray);
        //if (BuildTargetInt == 3 || BuildTargetInt == 4)
            //CompressionQualityInt = EditorGUILayout.IntPopup("  Compression Quality", CompressionQualityInt, CompressionQualityString, IntArray);
        if (GUILayout.Button("批量设置"))
            LoopSetTexture();
    }

    public FilterMode SetFilterMode()
    {
        FilterMode filterMode = FilterMode.Point;
        switch (FilterModeInt)
        {
            case 0:
                filterMode = FilterMode.Point;
                break;
            case 1:
                filterMode = FilterMode.Bilinear;
                break;
            case 2:
                filterMode = FilterMode.Trilinear;
                break;
        }
        return filterMode;
    }

    public TextureWrapMode SetWrapMode()
    {
        TextureWrapMode wrapMode = TextureWrapMode.Clamp;
        //Wrap Mode
        switch (WrapModeInt)
        {
            case 0:
                wrapMode = TextureWrapMode.Repeat;
                break;
            case 1:
                wrapMode = TextureWrapMode.Clamp;
                break;
        }
        return wrapMode;
    }

    public int SetMaxSize()
    {
        int maxTextureSize = 5;
        switch (MaxSizeInt)
        {
            case 0:
                maxTextureSize = 32;
                break;
            case 1:
                maxTextureSize = 64;
                break;
            case 2:
                maxTextureSize = 128;
                break;
            case 3:
                maxTextureSize = 256;
                break;
            case 4:
                maxTextureSize = 512;
                break;
            case 5:
                maxTextureSize = 1024;
                break;
            case 6:
                maxTextureSize = 2048;
                break;
            case 7:
                maxTextureSize = 4096;
                break;
        }
        return maxTextureSize;
    }

    public TextureImporterFormat SetTextureImporterFormat()
    {
        TextureImporterFormat textureFormat = TextureImporterFormat.AutomaticCompressed;
        switch (FormatInt)
        {
            case 0:
                textureFormat = TextureImporterFormat.AutomaticCompressed;
                break;
            case 1:
                textureFormat = TextureImporterFormat.Automatic16bit;
                break;
            case 2:
                textureFormat = TextureImporterFormat.AutomaticTruecolor;
                break;
            case 3:
                textureFormat = TextureImporterFormat.AutomaticCrunched;
                break;
        }
        return textureFormat;
    }

    /// <summary>
    /// 获取贴图设置
    /// </summary>
    public TextureImporter GetTextureSettings(string path)
    {
        TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        //Texture Type
        switch (TextureTypeInt)
        {
            case 0:
                textureImporter.textureType = TextureImporterType.Image;
                textureImporter.wrapMode = SetWrapMode();
                break;
            case 1:
                textureImporter.textureType = TextureImporterType.Bump;
                break;
            case 2:
                textureImporter.textureType = TextureImporterType.GUI;
                break;
            case 3:
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.mipmapEnabled = GenerateMipMaps;
                break;
            case 4:
                textureImporter.textureType = TextureImporterType.Cursor;
                break;
            case 5:
                textureImporter.textureType = TextureImporterType.Cubemap;
                break;
            case 6:
                textureImporter.textureType = TextureImporterType.Cookie;
                break;
            case 7:
                textureImporter.textureType = TextureImporterType.Lightmap;
                break;
            case 8:
                textureImporter.textureType = TextureImporterType.Advanced;
                textureImporter.wrapMode = SetWrapMode();
                textureImporter.mipmapEnabled = GenerateMipMaps;
                textureImporter.isReadable = ReadOrWriteEnabled;
                break;
        }
        SetFilterMode();

        switch (TextureTypeInt)
        {
            case 0:
                textureImporter.SetPlatformTextureSettings("iPhone", SetMaxSize(), TextureImporterFormat.AutomaticCompressed);
                textureImporter.SetPlatformTextureSettings("Android", SetMaxSize(), TextureImporterFormat.AutomaticCompressed);
                textureImporter.SetAllowsAlphaSplitting(true);
                break;
            case 3:
                textureImporter.SetPlatformTextureSettings("iPhone", SetMaxSize(), TextureImporterFormat.AutomaticCompressed);
                textureImporter.SetPlatformTextureSettings("Android", SetMaxSize(), TextureImporterFormat.AutomaticCompressed);
                textureImporter.SetAllowsAlphaSplitting(true);
                break;
            case 8:
                textureImporter.SetPlatformTextureSettings("iPhone", SetMaxSize(), TextureImporterFormat.PVRTC_RGBA4);
                textureImporter.SetPlatformTextureSettings("Android", SetMaxSize(), TextureImporterFormat.ETC2_RGBA8);
                break;
            default:
                textureImporter.ClearPlatformTextureSettings("iPhone");
                textureImporter.ClearPlatformTextureSettings("Android");
                break;
        }
        return textureImporter;
    }
    /// <summary>
    /// 循环设置选择的贴图
    /// </summary>
    private void LoopSetTexture()
    {
        Object[] textures = GetSelectedTextures();
        Selection.objects = new Object[0];
        foreach (Texture2D texture in textures)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            TextureImporter texImporter = GetTextureSettings(path);
            TextureImporterSettings tis = new TextureImporterSettings();
            texImporter.ReadTextureSettings(tis);
            texImporter.SetTextureSettings(tis);
            AssetDatabase.ImportAsset(path);
        }
    }
    /// <summary>
    /// 获取选择的贴图
    /// </summary>
    /// <returns></returns>
    private Object[] GetSelectedTextures()
    {
        return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
    }
}
#endif