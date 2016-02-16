using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 资源加载管理器
/// </summary>
public class WwwLoaderManager
{
	public static readonly WwwLoaderManager instance = new WwwLoaderManager();

	// 加载进度
	public delegate void DelegateLoaderProgress(string path, float currentValue, float totalValue);
	// 加载完成
	public delegate void DelegateLoaderComplete ();
	
	/// <summary>
	/// 加载顺序列表
	/// </summary>
	private IList<WwwLoaderOrder> orderList;

	/// <summary>
	/// 当前加载对象
	/// </summary>
	private WwwLoaderObject wwwLoaderObject;

	/// <summary>
	/// 当前加载顺序对象
	/// </summary>
	private WwwLoaderOrder wwwLoaderOrder;

	/// <summary>
	/// 当前加载路径
	/// </summary>
	private WwwLoaderPath wwwLoaderPath;

	/// <summary>
	/// 当前加载状态
	/// </summary>
	private bool loaderStatus = false;

	/// <summary>
	/// 加载
	/// </summary>
	/// <param name="pathList">Path list.</param>
	/// <param name="loaderProgress">Loader progress.</param>
	/// <param name="loaderComplete">Loader complete.</param>
	/// <param name="moduleName">Module name.</param>
	public void Loader(IList<WwwLoaderPath> pathList, WwwLoaderManager.DelegateLoaderProgress loaderProgress, WwwLoaderManager.DelegateLoaderComplete loaderComplete, string moduleName)
	{
		if(this.orderList == null) this.orderList = new List<WwwLoaderOrder>();

		WwwLoaderOrder wwwLoaderOrder = this.GetWwwLoaderOrderByOrderName (moduleName);
		if (wwwLoaderOrder == null) 
		{
			wwwLoaderOrder = new WwwLoaderOrder (moduleName, pathList, loaderProgress, loaderComplete);
			this.orderList.Add (wwwLoaderOrder);
		} else {
			wwwLoaderOrder.AttachEvent(loaderProgress, loaderComplete);
		}

		if (this.orderList != null && this.orderList.Count > 0 && !this.loaderStatus) 
		{
			this.LoaderOrder ();
		}
	}

	/// <summary>
	/// 加载顺序
	/// </summary>
	private void LoaderOrder()
	{
		if (this.orderList.Count > 0) 
		{
			this.loaderStatus = true;
			this.wwwLoaderOrder = this.orderList [0];
			this.LoaderItem ();
		} else {
			this.loaderStatus = false;
		}
	}

	/// <summary>
	/// 加载对象
	/// </summary>
	private void LoaderItem()
	{
		if (this.wwwLoaderOrder != null && this.wwwLoaderOrder.pathList.Count > 0) 
		{
			this.wwwLoaderPath = this.wwwLoaderOrder.pathList[0];
			//检查是否在缓存对象中，是否已经加载过
			bool existsStatus = WwwDataManager.instance.ExistsData(this.wwwLoaderPath.path);
			if(!existsStatus)
			{
				if(this.wwwLoaderObject == null) this.wwwLoaderObject = new WwwLoaderObject();
				this.wwwLoaderObject.Loader(this.wwwLoaderPath.path, this.wwwLoaderPath.loaderTypeEnum, this.wwwLoaderPath.version, OnProgressHandler, OnCompleteHandler, OnErrorHandler);
			}else{
				this.LoaderOperater(false, null);
			}
		} else {
			if(this.wwwLoaderOrder != null)
			{
				if(this.wwwLoaderOrder.wwwLoaderOrderEvent != null) this.wwwLoaderOrder.wwwLoaderOrderEvent.InvokeLoaderComplete();
				this.orderList.Remove(this.wwwLoaderOrder);
			}
			this.LoaderOrder();
		}
	}

	/// <summary>
	/// 加载进度
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="currentValue">Current value.</param>
	/// <param name="totalValue">Total value.</param>
	private void OnProgressHandler(string path, float currentValue, float totalValue)
	{
		if (this.wwwLoaderOrder != null && this.wwwLoaderOrder.wwwLoaderOrderEvent != null) this.wwwLoaderOrder.wwwLoaderOrderEvent.InvokeLoaderProgress(path, currentValue, totalValue);
	}

	/// <summary>
	/// 加载完成
	/// </summary>
	/// <param name="www">Www.</param>
	private void OnCompleteHandler(WWW www)
	{
		this.LoaderOperater (true, www);
	}

	/// <summary>
	/// 加载错误
	/// </summary>
	/// <param name="errorText">Error text.</param>
	private void OnErrorHandler(string errorText)
	{
		this.LoaderOperater (false, null);
	}

	/// <summary>
	/// 加载数据操作
	/// </summary>
	/// <param name="operaterType">If set to <c>true</c> operater type.</param>
	/// <param name="www">Www.</param>
	private void LoaderOperater(bool operaterType, WWW www)
	{
		if (this.wwwLoaderOrder == null || this.wwwLoaderPath == null) return;

		if (operaterType) 
		{
			if(this.wwwLoaderPath.loaderTypeEnum != WwwLoaderTypeEnum.UNITY_3D)
			{
				WwwData wwwData = new WwwData (this.wwwLoaderPath.path, this.wwwLoaderPath.loaderTypeEnum, www);
				WwwDataManager.instance.InsertData(wwwData);
			}
		}
		this.wwwLoaderOrder.pathList.Remove (this.wwwLoaderPath);

		if (this.wwwLoaderObject != null) this.wwwLoaderObject.UnLoader (false);
		
		this.LoaderItem ();
	}

	/// <summary>
	/// 根据序列名称检索加载序列
	/// </summary>
	/// <returns>The www loader order by order name.</returns>
	/// <param name="orderName">Order name.</param>
	private WwwLoaderOrder GetWwwLoaderOrderByOrderName(string orderName)
	{
		if (this.orderList == null || this.orderList.Count == 0) return null;
		
		foreach (WwwLoaderOrder wwwLoaderOrder in this.orderList) 
		{
			if(wwwLoaderOrder.orderName == orderName) return wwwLoaderOrder;
		}
		return null;
	}
}
