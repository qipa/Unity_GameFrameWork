//using UnityEngine;
//using UnityEditor;

//public class ChangeTextureImportSettings
//{

//    #region 改变图片的FilterMode
//    [MenuItem("Tools/Texture/Change Texture FilterMode/Trilinear")]
//    static void ChangeTextureFilterMode_Trilinear()
//    {
//        SelectedChangeTextureFilterMode(FilterMode.Trilinear);
//    }
//    [MenuItem("Tools/Texture/Change Texture FilterMode/Point")]
//    static void ChangeTextureFilterMode_Point()
//    {
//        SelectedChangeTextureFilterMode(FilterMode.Point);
//    }
//    [MenuItem("Tools/Texture/Change Texture FilterMode/Bilinear")]
//    static void ChangeTextureFilterMode_Bilinear()
//    {
//        SelectedChangeTextureFilterMode(FilterMode.Bilinear);
//    }
//    static void SelectedChangeTextureFilterMode(FilterMode newFormat)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            //Debug.Log("path: " + path);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.filterMode = newFormat;
//            AssetDatabase.ImportAsset(path);
//        }
//    }
//    #endregion

//    #region 改变图片的Format
//    [MenuItem("Tools/Texture/Change Texture Format/Auto")]
//    static void ChangeTextureFormat_Auto()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.AutomaticCompressed);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGB Compressed DXT1")]
//    static void ChangeTextureFormat_RGB_DXT1()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.DXT1);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGB Compressed DXT5")]
//    static void ChangeTextureFormat_RGB_DXT5()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.DXT5);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGB 16 bit")]
//    static void ChangeTextureFormat_RGB_16bit()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.RGB16);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGB 24 bit")]
//    static void ChangeTextureFormat_RGB_24bit()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.RGB24);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/Alpha 8 bit")]
//    static void ChangeTextureFormat_Alpha_8bit()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.Alpha8);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGBA 16 bit")]
//    static void ChangeTextureFormat_RGBA_16bit()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.ARGB16);
//    }
//    [MenuItem("Tools/Texture/Change Texture Format/RGBA 32 bit")]
//    static void ChangeTextureFormat_RGBA_32bit()
//    {
//        SelectedChangeTextureFormatSettings(TextureImporterFormat.ARGB32);
//    }
//    static void SelectedChangeTextureFormatSettings(TextureImporterFormat newFormat)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            //Debug.Log("path: " + path);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.textureFormat = newFormat;
//            AssetDatabase.ImportAsset(path);
//        }
//    } 
//    #endregion

//    #region 改变图片的maxsize
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/32")]
//    static void ChangeTextureSize_32()
//    {
//        SelectedChangeMaxTextureSize(32);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/64")]
//    static void ChangeTextureSize_64()
//    {
//        SelectedChangeMaxTextureSize(64);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/128")]
//    static void ChangeTextureSize_128()
//    {
//        SelectedChangeMaxTextureSize(128);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/256")]
//    static void ChangeTextureSize_256()
//    {
//        SelectedChangeMaxTextureSize(256);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/512")]
//    static void ChangeTextureSize_512()
//    {
//        SelectedChangeMaxTextureSize(512);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/1024")]
//    static void ChangeTextureSize_1024()
//    {
//        SelectedChangeMaxTextureSize(1024);
//    }
//    [MenuItem("Tools/Texture/Change Texture Size/Change Max Texture Size/2048")]
//    static void ChangeTextureSize_2048()
//    {
//        SelectedChangeMaxTextureSize(2048);
//    }
//    static void SelectedChangeMaxTextureSize(int size)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.maxTextureSize = size;
//            AssetDatabase.ImportAsset(path);
//        }
//    } 
//    #endregion

//    #region 是否打开图片的MipMap
//    [MenuItem("Tools/Texture/Change MipMap/Enable MipMap")]
//    static void ChangeMipMap_On()
//    {
//        SelectedChangeMimMap(true);
//    }
//    [MenuItem("Tools/Texture/Change MipMap/Disable MipMap")]
//    static void ChangeMipMap_Off()
//    {
//        SelectedChangeMimMap(false);
//    }
//    static void SelectedChangeMimMap(bool enabled)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.mipmapEnabled = enabled;
//            AssetDatabase.ImportAsset(path);
//        }
//    } 
//    #endregion

//    #region 更改图片的Type
//    [MenuItem("Tools/Texture/Change Texture Type/Advanced")]
//    static void ChangeTextureType_Advanced()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Advanced);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Normal Map")]
//    static void ChangeTextureType_Bump()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Bump);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Cookie")]
//    static void ChangeTextureType_Cookie()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Cookie);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Reflection")]
//    static void ChangeTextureType_Cubemap()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Cubemap);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Cursor")]
//    static void ChangeTextureType_Cursor()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Cursor);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/GUI")]
//    static void ChangeTextureType_GUI()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.GUI);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Image")]
//    static void ChangeTextureType_Image()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Image);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Lightmap")]
//    static void ChangeTextureType_Lightmap()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Lightmap);
//    }
//    [MenuItem("Tools/Texture/Change Texture Type/Sprite")]
//    static void ChangeTextureType_Sprite()
//    {
//        SelectedChangeTextureTypeSettings(TextureImporterType.Sprite);
//    }
//    static void SelectedChangeTextureTypeSettings(TextureImporterType newFormat)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            //Debug.Log("path: " + path);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.textureType = newFormat;
//            AssetDatabase.ImportAsset(path);
//        }
//    } 
//    #endregion

//    #region 图片是否可读写
//    [MenuItem("Tools/Texture/Change ReadWrite/Enable ReadWrite")]
//    static void ChangeRead_On()
//    {
//        SelectedChangeReadOrWrite(true);
//    }
//    [MenuItem("Tools/Texture/Change ReadWrite/Disable ReadWrite")]
//    static void ChangeRead_Off()
//    {
//        SelectedChangeReadOrWrite(false);
//    }
//    static void SelectedChangeReadOrWrite(bool enabled)
//    {
//        Object[] textures = GetSelectedTextures();
//        Selection.objects = new Object[0];
//        foreach (Texture2D texture in textures)
//        {
//            string path = AssetDatabase.GetAssetPath(texture);
//            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
//            textureImporter.isReadable = enabled;
//            AssetDatabase.ImportAsset(path);
//        }
//    }
//    #endregion

//    static Object[] GetSelectedTextures()
//    {
//        return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
//    }
//}
