using UnityEngine;
using System.Collections;

/// <summary>
/// 单个对象加载管理器
/// </summary>
public class WwwLoaderItem : MonoBehaviour
{
	// 加载进度
	public delegate void DelegateLoaderProgress(string path, float currentValue, float totalValue);
	// 加载完成
	public delegate void DelegateLoaderComplete(WWW data);
	// 加载出错
	public delegate void DelegateLoaderError (string errorText);

	// 加载进度
	public event DelegateLoaderProgress OnProgress;
	// 加载完成
	public event DelegateLoaderComplete OnComplete;
	// 加载出错
	public event DelegateLoaderError OnError;

	/// <summary>
	/// 加载状态
	/// </summary>
	private bool progressStatus = false;

	/// <summary>
	/// 加载对象
	/// </summary>
	private WWW www;

	/// <summary>
	/// 调用进度事件
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="currentValue">Current value.</param>
	/// <param name="totalValue">Total value.</param>
	private void InvokeProgress(string path, float currentValue, float totalValue)
	{
		if (this.OnProgress != null) this.OnProgress (path, currentValue, totalValue);
	}
	/// <summary>
	/// 调用完成事件
	/// </summary>
	/// <param name="data">Data.</param>
	private void InvokeComplete(WWW data)
	{
		if (this.OnComplete != null) this.OnComplete (data);
	}
	/// <summary>
	/// 调用出错事件
	/// </summary>
	/// <param name="loaderEnum">Loader enum.</param>
	private void InvokeError(string errorText)
	{
		if (this.OnError != null) this.OnError (errorText);
	}

	/// <summary>
	/// 开始加载
	/// </summary>
	/// <param name="path">Path.</param>
	public void Loader(string path, WwwLoaderTypeEnum loaderTypeEnum, int version)
	{
		this.progressStatus = false;
		this.StartCoroutine (LoaderBegin(path, loaderTypeEnum, version));
	}

	/// <summary>
	/// 开始加载
	/// </summary>
	/// <returns>The begin.</returns>
	/// <param name="path">Path.</param>
	private IEnumerator LoaderBegin(string path, WwwLoaderTypeEnum loaderTypeEnum, int version)
	{
		// 说明，这儿只有 场景（默认是把场景打包成 Unity3D 后缀文件） 使用缓存池加载，因为不用缓存池加载方法，无法使用 Application.LoadLevel 加载场景
		// 可能是自己理解的不多，还是本来就应该是这样，这儿可以按照自己的处理方式进行调整
		if (loaderTypeEnum == WwwLoaderTypeEnum.UNITY_3D) 
		{
			this.www = WWW.LoadFromCacheOrDownload(path, version);
		} else {
			this.www = new WWW(path);
		}
		yield return this.www;

		if (!string.IsNullOrEmpty (this.www.error)) 
		{
			this.InvokeError (this.www.error);
		} 
		else 
		{
			if (this.www.isDone) 
			{
				this.InvokeComplete (this.www);
			} 
		}
		this.StopCoroutine (LoaderBegin(path, loaderTypeEnum, version));
	}

	/// <summary>
	/// 触发加载进度
	/// </summary>
	void Update()
	{
		if (this.www != null && !this.progressStatus) 
		{
			if(this.www.progress >= 1) this.progressStatus = true;
			this.InvokeProgress (this.www.url, this.www.progress, 1);
		}
	}
	
	/// <summary>
	/// 销毁对象
	/// </summary>
	public void UnLoader()
	{
		Destroy (this.gameObject);
	}
	
	/// <summary>
	/// 销毁自己
	/// </summary>
	public void UnLoaderThis()
	{
		Destroy (this);
	}
}
