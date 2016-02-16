using UnityEngine;
using System.Collections;

/// <summary>
/// 加载路径结构
/// </summary>
public class WwwLoaderPath
{
	/// <summary>
	/// 加载路径
	/// </summary>
	public string path;

	/// <summary>
	/// 资源版本号
	/// </summary>
	public int version;

	/// <summary>
	/// 资源类别
	/// </summary>
	public WwwLoaderTypeEnum loaderTypeEnum;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="version">Version.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	public WwwLoaderPath(string path, int version, WwwLoaderTypeEnum loaderTypeEnum)
	{
		this.path = path;
		this.version = version;
		this.loaderTypeEnum = loaderTypeEnum;
	}
}
