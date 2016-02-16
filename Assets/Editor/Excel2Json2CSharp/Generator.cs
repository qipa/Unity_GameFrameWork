using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Excel;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Xamasoft.JsonClassGenerator;
using System;
using Xamasoft.JsonClassGenerator.CodeWriters;

public class Generator
{
    /// <summary>
    /// 转换为Json
    /// </summary>
    public static bool Excel2Json(string _excelPath, string _jsonPath)
    {
        Encoding encoding = Encoding.UTF8;

        DirectoryInfo folder = new DirectoryInfo(_excelPath);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        int length = files.Length;

        for (int index = 0; index < length; index++)
        {
            if (files[index].Name.EndsWith(".xlsx"))
            {
                string childPath = files[index].FullName;

                FileStream mStream = File.Open(childPath, FileMode.Open, FileAccess.Read);
                IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
                DataSet mResultSet = mExcelReader.AsDataSet();

                //判断Excel文件中是否存在数据表
                if (mResultSet.Tables.Count < 1)
                    return false;

                //默认读取第一个数据表
                DataTable mSheet = mResultSet.Tables[0];
                string jsonName = mSheet.TableName;

                //判断数据表内是否存在数据
                if (mSheet.Rows.Count < 1)
                    return false;

                //读取数据表行数和列数
                int rowCount = mSheet.Rows.Count;
                int colCount = mSheet.Columns.Count;

                //准备一个列表存储整个表的数据
                List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();

                //读取数据
                for (int i = 2; i < rowCount; i++)
                {
                    //准备一个字典存储每一行的数据
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for (int j = 0; j < colCount; j++)
                    {
                        //读取第1行数据作为表头字段
                        string field = mSheet.Rows[1][j].ToString();
                        //Key-Value对应
                        row[field] = mSheet.Rows[i][j];
                    }

                    //添加到表数据中
                    table.Add(row);
                }

                //生成Json字符串
                string json = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
                //写入文件
                using (FileStream fileStream = new FileStream(_jsonPath + "/" + jsonName + ".json", FileMode.Create, FileAccess.Write))
                {
                    using (TextWriter textWriter = new StreamWriter(fileStream, encoding))
                    {
                        textWriter.Write(json);
                    }
                }
            }
        }

        return true;
    }


    public static bool Json2CSharp(string _jsonPath, string _csharpPath)
    {
        Encoding encoding = Encoding.UTF8;

        DirectoryInfo folder = new DirectoryInfo(_jsonPath);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        int length = files.Length;


        for (int index = 0; index < length; index++)
        {
            if (files[index].Name.EndsWith(".json"))
            {
                string csName = files[index].Name;
                csName = csName.Substring(0, csName.LastIndexOf("."));

                string csContent = "";
                using (StreamReader textReader = new StreamReader(files[index].FullName, Encoding.UTF8))
                {
                    string str = textReader.ReadToEnd();//读取文件
                    csContent = str;
                    textReader.Close();
                }

                JsonClassGenerator gen = Prepare(csContent, _csharpPath,csName);
                if (gen == null) return false;

                try
                {
                    gen.GenerateClasses();
                }
                catch (Exception ex)
                {
                    Debug.Log("Unable to generate the code: " + ex.Message);
                    return false;
                }


                //				//写入文件
                //				using (FileStream fileStream = new FileStream(_csharpPath + "/" + csName + ".cs", FileMode.Create, FileAccess.Write))
                //				{
                //					using (TextWriter textWriter = new StreamWriter(fileStream, encoding))
                //					{
                //						textWriter.Write(csContent);
                //					}
                //				}
            }
        }
        return true;
    }

    private static JsonClassGenerator Prepare(string _jsonData,string _csharpPath,string _csName)
    {
        if (_jsonData == string.Empty)
        {
            Debug.Log("Please insert some sample JSON.");
            return null;
        }

        JsonClassGenerator gen = new JsonClassGenerator();
        gen.Example = _jsonData;
        gen.InternalVisibility = false;
        gen.CodeWriter = new CSharpCodeWriter();
        gen.ExplicitDeserialization = false;
        gen.Namespace = "HuanJueGameData";
        gen.NoHelperClass = true;
        gen.SecondaryNamespace = null;
        gen.TargetFolder = _csharpPath;
        gen.UseProperties = true;
        gen.MainClass = _csName;
        gen.UsePascalCase = false;
        gen.UseNestedClasses = false;
        gen.ApplyObfuscationAttributes = false;
        gen.SingleFile = true;
        gen.ExamplesInDocumentation = false;
        return gen;
    }
}

