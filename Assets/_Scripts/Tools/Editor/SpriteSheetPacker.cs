using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class SpriteSheetPacker
{
    /// <summary>
    ///功能： 把一张图集大图分割成对应的小图
    ///使用方法:选择Texture Type类型为Advanced 将Read/Write Enabled选上
    ///把sprite mode改成multiple 然后点下面的sprite editor 左上角slice自动切割
    /// </summary>
    [MenuItem("Tools/Sprite Sheet Packer/Process to Sprites")]
    static void ProcessToSprite()
    {
        Texture2D texture2D = Selection.activeObject as Texture2D;
        if (texture2D == null)
        {
            Debug.Log("没有选择图片"); return;
        }
        string rootPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(texture2D));
        if (string.IsNullOrEmpty(rootPath)) return;
        string imgPath = rootPath + "/" + texture2D.name + ".png";
        string filePath = rootPath + "/" + texture2D.name;
        TextureImporter textImp = AssetImporter.GetAtPath(imgPath) as TextureImporter;
        if (!Directory.Exists(filePath))
        {
            AssetDatabase.CreateFolder(rootPath, texture2D.name);
            Debug.Log(rootPath + "/" + texture2D.name);
        }
        foreach (var metaData in textImp.spritesheet)
        {
            Texture2D myimage = new Texture2D((int)metaData.rect.width, (int)metaData.rect.height);
            for (int y = (int)metaData.rect.y; y < metaData.rect.y + metaData.rect.height; y++)
            {
                for (int x = (int)metaData.rect.x; x < metaData.rect.x + metaData.rect.width; x++)
                    myimage.SetPixel(x - (int)metaData.rect.x, y - (int)metaData.rect.y, texture2D.GetPixel(x, y));
            }
            if (myimage.format != TextureFormat.ARGB32 && myimage.format != TextureFormat.RGB24)
            {
                Texture2D newTexture = new Texture2D(myimage.width, myimage.height);
                newTexture.SetPixels(myimage.GetPixels(0), 0);
                myimage = newTexture;
            }
            myimage.Apply();
            var pngData = myimage.EncodeToPNG();
            File.WriteAllBytes(rootPath + "/" + texture2D.name + "/" + metaData.name + ".PNG", pngData);
        }
        AssetDatabase.Refresh();
    }
}
