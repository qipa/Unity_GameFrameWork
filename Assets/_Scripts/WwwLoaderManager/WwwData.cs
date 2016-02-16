using UnityEngine;
using System.Collections;

/// <summary>
/// 加载完成资源存储结构
/// </summary>
public class WwwData
{
	/// <summary>
	/// 加载路径
	/// </summary>
	public string path;

	/// <summary>
	/// 加载类型枚举
	/// </summary>
	public WwwLoaderTypeEnum loaderTypeEnum;

	/// <summary>
	/// 加载完成之后的数据
	/// </summary>
	public WWW www;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	/// <param name="www">Www.</param>
	/// <param name="loaderDestroyTypeEnum">Loader destroy type enum.</param>
	public WwwData(string path, WwwLoaderTypeEnum loaderTypeEnum, WWW www)
	{
		this.path = path;
		this.loaderTypeEnum = loaderTypeEnum;
		this.www = www;
	}
}
