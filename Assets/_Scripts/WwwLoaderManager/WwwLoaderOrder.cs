using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 顺序加载管理器
/// </summary>
public class WwwLoaderOrder
{
	/// <summary>
	/// 队列名称
	/// </summary>
	public string orderName;

	/// <summary>
	/// 路径列表
	/// </summary>
	public IList<WwwLoaderPath> pathList;

	/// <summary>
	/// 队列事件
	/// </summary>
	public WwwLoaderOrderEvent wwwLoaderOrderEvent;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="orderName">Order name.</param>
	/// <param name="pathList">Path list.</param>
	/// <param name="loaderProgress">Loader progress.</param>
	/// <param name="loaderComplete">Loader complete.</param>
	public WwwLoaderOrder(string orderName, IList<WwwLoaderPath> pathList, WwwLoaderManager.DelegateLoaderProgress loaderProgress, WwwLoaderManager.DelegateLoaderComplete loaderComplete)
	{
		this.orderName = orderName;
		this.pathList = pathList;

		this.AttachEvent (loaderProgress, loaderComplete);
	}

	/// <summary>
	/// 附加事件
	/// </summary>
	/// <param name="loaderProgress">Loader progress.</param>
	/// <param name="loaderComplete">Loader complete.</param>
	public void AttachEvent(WwwLoaderManager.DelegateLoaderProgress loaderProgress, WwwLoaderManager.DelegateLoaderComplete loaderComplete)
	{
		if (this.wwwLoaderOrderEvent == null) 
		{
			this.wwwLoaderOrderEvent = new WwwLoaderOrderEvent();
		}
		
		if(loaderProgress != null) this.wwwLoaderOrderEvent.OnLoaderProgress += loaderProgress;
		if(loaderComplete != null) this.wwwLoaderOrderEvent.OnLoaderComplete += loaderComplete;
	}
	
	/// <summary>
	/// 移除事件
	/// </summary>
	/// <param name="loaderProgress">Loader progress.</param>
	/// <param name="loaderComplete">Loader complete.</param>
	public void RemoveEvent(WwwLoaderManager.DelegateLoaderProgress loaderProgress, WwwLoaderManager.DelegateLoaderComplete loaderComplete)
	{
		if (this.wwwLoaderOrderEvent == null) return;
		
		if(loaderProgress != null) this.wwwLoaderOrderEvent.OnLoaderProgress -= loaderProgress;
		if(loaderComplete != null) this.wwwLoaderOrderEvent.OnLoaderComplete -= loaderComplete;
	}
}
