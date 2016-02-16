using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Collections.Generic;

public class IOHelper {

    /// <summary>
    /// 判断文件是否存在
    /// </summary>
    public static bool IsFileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    /// <summary>
    /// 判断文件夹是否存在
    /// </summary>
    public static bool IsDirectoryExists(string fileName)
    {
        return Directory.Exists(fileName);
    }

    /// <summary>
    /// 创建文件.
    /// </summary>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">文件的名称.</param>
    /// <param name="info">写入的内容.</param>
    public void CreateFile(string path, string name, string info)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(path + name);
        if (!t.Exists)
            sw = t.CreateText();
        else
            sw = t.AppendText();
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// 创建一个文件夹
    /// </summary>
    public static void CreateFolder(string fileName)
    {
        //文件夹存在则返回
        if (IsDirectoryExists(fileName))
            return;
        Directory.CreateDirectory(fileName);
    }

    /// <summary>
    /// 读取文件.
    /// </summary>
    /// <returns>The file.</returns>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">读取文件的名称.</param>
    public ArrayList LoadFile(string path, string name)
    {
        //使用流的形式读取
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + name);
        }
        catch (Exception e)
        {
            return null;
        }
        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            arrlist.Add(line);
        }
        sr.Close();
        sr.Dispose();
        return arrlist;
    }

    /// <summary>
    /// 获取指定文件大小
    /// </summary>
    /// <param name="FilePath"></param>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public int GetFileSize(string FilePath, string FileName)
    {
        int sum = 0;
        if (!Directory.Exists(FilePath))
        {
            return 0;
        }
        else
        {
            FileInfo Files = new FileInfo(@FilePath + FileName);
            sum += Convert.ToInt32(Files.Length / 1024);
        }
        return sum;
    }

    /// <summary>
    /// 删除文件.
    /// </summary>
    /// <param name="path">删除完整文件夹路径.</param>
    /// <param name="name">删除文件的名称.</param>
    public void DeleteFile(string path, string name)
    {
        File.Delete(path + name);
    }


    public bool DeleteFiles(string path, string filesName)
    {
        bool isDelete = false;
        try
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path + "\\" + filesName))
                {
                    File.Delete(path + "\\" + filesName);
                    isDelete = true;
                }
            }
        }
        catch
        {
            return isDelete;
        }
        return isDelete;
    }

    public static void SetData(string fileName, object pObject)
    {
        //将对象序列化为字符串
        string toSave = SerializeObject(pObject);
        //对字符串进行加密,32位加密密钥
        toSave = EncryptionContent(toSave, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        StreamWriter streamWriter = File.CreateText(fileName);
        streamWriter.Write(toSave);
        streamWriter.Close();
    }

    public static object GetData(string fileName, Type pType)
    {
        StreamReader streamReader = File.OpenText(fileName);
        string data = streamReader.ReadToEnd();
        //对数据进行解密，32位解密密钥
        data = DecipheringContent(data, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        streamReader.Close();
        return DeserializeObject(data, pType);
    }

    /// <summary>
    /// Rijndael加密算法
    /// </summary>
    /// <param name="pString">待加密的明文</param>
    /// <param name="pKey">密钥,长度可以为:64位(byte[8]),128位(byte[16]),192位(byte[24]),256位(byte[32])</param>
    /// <param name="iv">iv向量,长度为128（byte[16])</param>
    /// <returns></returns>
    private static string EncryptionContent(string pString, string pKey)
    {
        //密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待加密明文数组
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        //返回加密后的密文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    /// <summary>
    /// ijndael解密算法
    /// </summary>
    /// <param name="pString">待解密的密文</param>
    /// <param name="pKey">密钥,长度可以为:64位(byte[8]),128位(byte[16]),192位(byte[24]),256位(byte[32])</param>
    /// <param name="iv">iv向量,长度为128（byte[16])</param>
    /// <returns></returns>
    private static String DecipheringContent(string pString, string pKey)
    {
        //解密密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待解密密文数组
        byte[] toEncryptArray = Convert.FromBase64String(pString);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        //返回解密后的明文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }


    /// <summary>
    /// 将一个对象序列化为字符串
    /// </summary>
    /// <returns>The object.</returns>
    /// <param name="pObject">对象</param>
    /// <param name="pType">对象类型</param>
    private static string SerializeObject(object pObject)
    {
        //序列化后的字符串
        string serializedString = string.Empty;
        //使用Json.Net进行序列化
        serializedString = JsonConvert.SerializeObject(pObject);
        return serializedString;
    }

    /// <summary>
    /// 将一个字符串反序列化为对象
    /// </summary>
    /// <returns>The object.</returns>
    /// <param name="pString">字符串</param>
    /// <param name="pType">对象类型</param>
    private static object DeserializeObject(string pString, Type pType)
    {
        //反序列化后的对象
        object deserializedObject = null;
        //使用Json.Net进行反序列化
        deserializedObject = JsonConvert.DeserializeObject(pString, pType);
        return deserializedObject;
    }

    /// <summary>
    /// Xml文件转Json返回
    /// </summary>
    /// <param name="path">Xml文件路径</param>
    public static string Xml2Json(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path); // 通过xml的路径来读取xml文件
        string json = JsonConvert.SerializeXmlNode(doc.DocumentElement, Newtonsoft.Json.Formatting.None);
        return json;
    }

    /// <summary>
    /// Json转Xml文件
    /// </summary>
    /// <param name="json">Json字符串</param>
    /// <param name="savePath">保存路径</param>
    public static void Json2Xml(string json, string savePath)
    {
        try
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root");
            //CreateXmlFile(doc, savePath); //这里为了看得更加直观，我是将完成转化的XML格式保存到了xml文件中，这样就不需要再遍历节点来打印出来
            Console.WriteLine("Xml文件保存位置：" + savePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// 将json字符串转换成字典
    /// </summary>
    /// <param name="json">需要转换的json</param>
    /// <returns></returns>
    public static Dictionary<string, string> Json2Dictionary(string json)
    {
        Dictionary<string, string> _languageNode = new Dictionary<string, string>();
        try
        {
            _languageNode = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return _languageNode;
    }

    /// <summary>
    /// 将字典转换为json字符串
    /// </summary>
    /// <param name="dic">传入的字典</param>
    /// <returns></returns>
    public static string Dictionary2Json(object dic)
    {
        string str = null;
        try
        {
            str = JsonConvert.SerializeObject(dic, Newtonsoft.Json.Formatting.Indented);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return str;
    }
}
