using UnityEngine;
using System.Collections;
using UnityEditor;

public class AutoSetTextureUISprite : AssetPostprocessor
{

    //void OnPostprocessTexture(Texture2D texture)
    //{
    //    string AtlasName = new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
    //    TextureImporter textureImporter = assetImporter as TextureImporter;
    //    textureImporter.textureType = TextureImporterType.Sprite;
    //    textureImporter.spritePackingTag = AtlasName;
    //    textureImporter.mipmapEnabled = false;
    //}

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        //foreach (var str in importedAssets)
        //{
        //    if (!str.EndsWith(".cs"))
        //    {
        //        Debug.Log("Reimported Asset: " + str);
        //        AssetImporter importer = AssetImporter.GetAtPath(str);
        //        importer.assetBundleName = str;
        //    }
        //}

        //foreach (var str in deletedAssets)
        //{
        //    if (!str.EndsWith(".cs"))
        //    {
        //        Debug.Log("Deleted Asset: " + str);
        //        AssetImporter importer = AssetImporter.GetAtPath(str);
        //        importer.assetBundleName = str;
        //    }
        //}


        //foreach (var str in movedAssets)
        //{
        //    if (!str.EndsWith(".cs"))
        //    {
        //        Debug.Log("moved Asset: " + str);
        //        AssetImporter importer = AssetImporter.GetAtPath(str);
        //        importer.assetBundleName = str;
        //    }
        //}

        //foreach (var str in movedFromAssetPaths)
        //{
        //    if (!str.EndsWith(".cs"))
        //    {
        //        Debug.Log("movedFromAssetPaths: " + str);
        //        AssetImporter importer = AssetImporter.GetAtPath(str);
        //        importer.assetBundleName = str;
        //    }
        //}

        //for (var i = 0; i < movedAssets.Length; i++)
        //{

        //    //Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);

        //}

    }
}
