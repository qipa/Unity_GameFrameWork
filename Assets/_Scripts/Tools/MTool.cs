using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class MTool
{
    /// <summary>
    /// 改变UI的深度
    /// </summary>
    /// <param name="obj">将要插入的对象</param>
    /// <param name="go">将</param>
    public static void SetSiblingIndex(GameObject obj, GameObject go)
    {
        obj.transform.SetSiblingIndex(go.transform.GetSiblingIndex());
    }

    /// <summary>
    /// 两点之间直线的坐标计算.
    /// </summary>
    /// <returns>The line paht help.</returns>
    /// <param name="startPoint">起点.</param>
    /// <param name="endPoint">终点.</param>
    /// <param name="per">从起点到终点每间隔几米划分一个点.</param>
    public static List<Vector3> ToLinePahtHelp(Vector3 startPoint, Vector3 endPoint, float per = 0.27f)
    {
        List<Vector3> pointList = new List<Vector3>(777);
        Vector3 dir = (endPoint - startPoint).normalized;
        Vector3 currentPoint = Vector3.zero; ;
        float distance = Vector3.Distance(endPoint, startPoint);
        int number = (int)(distance / per);
        for (int i = 1; i < number + 1; i++)
        {
            currentPoint = startPoint + dir * (float)(i * per);
            pointList.Add(currentPoint);
        }
        return pointList;
    }

    public static float GetTwoPointDistance(Vector3 startPoint, Vector3 endPoint)
    {
        return Vector3.Distance(endPoint, startPoint);
    }

    /// <summary>
    /// 以IO方式进行加载图片
    /// </summary>
    private void LoadTextureByIO(int width, int height)
    {
        //创建文件读取流
        FileStream fileStream = new FileStream("D:\\test.jpg", FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// 以WWW的方式加载图片
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadTextureByWWW()
    {
        WWW www = new WWW("file://D:\\test.jpg");
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Texture2D texture = www.texture;
            //创建Sprite
            Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            www.Dispose();
        }
    }

    public static Texture2D CaptureCamera(Camera camera, Rect rect, int mapId)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        camera.targetTexture = rt;
        camera.Render();
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
        return screenShot;
    }

    public static void WritePng(byte[] bytes, int mapId, string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            //WriteFile(mapId, System.Text.Encoding.Default.GetString(bytes));
            string filename = path + "/Screen" + mapId + ".png";
            //File.Copy(filename, filename, true);
            try { File.WriteAllBytes(filename, bytes); }
            catch { }
        }
    }


    //public static IEnumerator CopyTexture(UITexture texture, int srcId, int targetId)
    //{
    //    yield return null;
    //    if (!string.IsNullOrEmpty(GetPersistentFilePath()))
    //    {
    //        string filename = GetPersistentFilePath() + "/Screen" + srcId + ".png";
    //        WWW www = new WWW("file://" + filename);
    //        yield return www;
    //        texture.mainTexture = www.texture;
    //        byte[] bytes = www.texture.EncodeToPNG();
    //        string filenames = GetPersistentFilePath() + "/Screen" + targetId + ".png";
    //        try
    //        {
    //            File.WriteAllBytes(filenames, bytes);
    //        }
    //        catch { }
    //    }
    //}

    //public static IEnumerator getCaptureTexture(UITexture texture, int mapId)
    //{
    //    yield return null;
    //    string filename = GetPersistentFilePath() + "/Screen" + mapId + ".png";
    //    WWW www = new WWW("file://" + filename);
    //    yield return www;
    //    if (string.IsNullOrEmpty(www.error))
    //    {
    //        texture.mainTexture = www.texture;
    //        www.Dispose();
    //    }
    //    else
    //        texture.mainTexture = Resources.Load("Texture/Screendefault_Missing") as Texture2D;
    //}

    public static string GetPersistentFilePath()
    {
        string filepath;
        if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            filepath = Application.dataPath;
        else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
            filepath = Application.persistentDataPath + "/";
        else
        {
            filepath = Application.persistentDataPath + "/";
        }
        return filepath;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrayCount">总数</param>
    /// <param name="catchCount">要随机出的个数</param>
    /// <returns></returns>
    public static int[] Array_RandomNoRepeatElement(int arrayCount, int catchCount)
    {
        if (catchCount > arrayCount)
        {
            Debug.LogError("The Array count can't less than catchCount.");
            return null;
        }
        int[] resultArray = new int[catchCount],
            originalArray = new int[arrayCount];
        for (int i = 0; i < arrayCount; i++)
        {
            originalArray[i] = i;
        }
        int randomIndex = 0, count = arrayCount, temp = 0;
        for (int i = 0; i < catchCount; i++)
        {
            randomIndex = UnityEngine.Random.Range(0, count);
            resultArray[i] = originalArray[randomIndex];
            if (randomIndex != count - 1)
            {
                temp = originalArray[randomIndex];
                originalArray[randomIndex] = originalArray[count - 1];
                originalArray[count - 1] = temp;
            }
            count--;
        }
        return resultArray;
    }

    public static string TimeToStringNew(float time)
    {
        StringBuilder timeString = new StringBuilder();
        System.TimeSpan t = System.TimeSpan.FromSeconds(time);
        int day = t.Days;
        int hour = t.Hours;
        int min = t.Minutes;
        int sec = t.Seconds;
        if (day > 0)
        {
            timeString.Append(day);
            timeString.Append(":");
            timeString.Append(hour);
            timeString.Append(":");
            timeString.Append(min);
            timeString.Append(":");
            timeString.Append(sec);
        }
        else if (hour > 0)
        {
            timeString.Append(hour);
            timeString.Append(":");
            timeString.Append(min);
            timeString.Append(":");
            timeString.Append(sec);
        }
        else if (min > 0)
        {
            timeString.Append(min);
            timeString.Append(":");
            timeString.Append(sec);
        }
        else
        {
            timeString.Append(sec);
        }
        return timeString.ToString();
    }

    //public static void SortDefSmallestToLargest()
    //{
    //    LocalValue.mIns.monsterStorage.Sort(
    //            (x, y) =>
    //            {
    //                if (x.roleValue.homeID == y.roleValue.homeID)
    //                {
    //                    int tmp = x.MonsterDef() - y.MonsterDef();
    //                    if (tmp == 0)
    //                    {
    //                        if (x.role.RoleID == y.role.RoleID)
    //                        {
    //                            return x.GetHashCode() - y.GetHashCode();
    //                        }
    //                        else
    //                            return x.role.RoleID - y.role.RoleID;
    //                    }
    //                    else
    //                        return tmp;
    //                }
    //                else
    //                {
    //                    return x.roleValue.homeID - y.roleValue.homeID;
    //                }
    //            });
    //}

    //public static int SortHeroLvLargestToSmallest(Transform a, Transform b)
    //{
    //    HeroItem x = a.gameObject.GetComponent<HeroItem>();
    //    HeroItem y = b.gameObject.GetComponent<HeroItem>();
    //    if (x == null || x.rv == null || y == null || y.rv == null) return -1;
    //    if (x.rv.Level == y.rv.Level)
    //    {
    //        return -(x.role.RoleRank / 100 - y.role.RoleRank / 100);
    //    }
    //    else
    //    {
    //        return -(x.rv.Level - y.rv.Level);
    //    }
    //}

    public static void DestroyChild(Transform t)
    {
        int count = t.childCount;
        Transform gt = t;
        for (int i = 0; i < count; i++)
        {
            GameObject.Destroy(gt.GetChild(i).gameObject);
        }
    }

    public static Color ToColor(int r, int b, int g)
    {
        return new Color(r / 255f, b / 255f, g / 255f);
    }
}
