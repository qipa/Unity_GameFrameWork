using UnityEngine;
using System.Collections;

/// <summary>
/// 顺序加载管理器事件
/// </summary>
public class WwwLoaderOrderEvent
{
	// 加载进度委托
	public WwwLoaderManager.DelegateLoaderProgress OnLoaderProgress;
	// 加载完成委托
	public WwwLoaderManager.DelegateLoaderComplete OnLoaderComplete;

	/// <summary>
	/// 触发进度委托函数
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="currentValue">Current value.</param>
	/// <param name="totalValue">Total value.</param>
	public void InvokeLoaderProgress(string path, float currentValue, float totalValue)
	{
		if (this.OnLoaderProgress != null) this.OnLoaderProgress (path, currentValue, totalValue);
	}

	/// <summary>
	/// 触发完成委托函数
	/// </summary>
	public void InvokeLoaderComplete()
	{
		if (this.OnLoaderComplete != null) this.OnLoaderComplete ();
	}
}
