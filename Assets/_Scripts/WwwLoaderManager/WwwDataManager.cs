using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 资源管理器
/// </summary>
public class WwwDataManager
{
	public static readonly WwwDataManager instance = new WwwDataManager();

	/// <summary>
	/// 加载缓存数据
	/// </summary>
	private Dictionary<string, WwwData> dataList;

	/// <summary>
	/// 所有未被释放的引用
	/// </summary>
	private IList<AssetBundle> assetList;

	/// <summary>
	/// 数据总数
	/// </summary>
	/// <returns>The count.</returns>
	public int dataCount()
	{
		if (this.dataList == null) return 0;
		return this.dataList.Keys.Count;
	}

	/// <summary>
	/// 添加数据到缓存
	/// </summary>
	/// <param name="wwwData">Www data.</param>
	public void InsertData(WwwData wwwData)
	{
		if (wwwData == null) return;
		// 如果为空，要创建
		if (this.dataList == null) this.dataList = new Dictionary<string, WwwData> ();
		this.dataList.Add (wwwData.path, wwwData);
	}

	/// <summary>
	/// 移除数据对象
	/// </summary>
	/// <param name="path">Path.</param>
	public void RemoveData(string path, bool destroy = false)
	{
		if (this.dataList == null || !this.dataList.ContainsKey (path)) return;

		WwwData wwwData = this.dataList [path];
		if (wwwData != null) 
		{
			// 释放引用的资源
			if(wwwData.www.assetBundle != null)
			{
				wwwData.www.assetBundle.Unload(false);
			}
			wwwData.www.Dispose();
			wwwData.www = null;
		}
		this.dataList.Remove (path);

		if (destroy) this.Destroy ();
	}
	
	/// <summary>
	/// 卸载资源
	/// </summary>
	/// <param name="path">Path.</param>
	public void UnloadData(string path)
	{
		AssetBundle assetBundle = this.GetDataAssetBundle (path);
		if (assetBundle != null) assetBundle.Unload (false);
	}

	/// <summary>
	/// 清除对象
	/// </summary>
	public void Destroy()
	{
		Resources.UnloadUnusedAssets();
	}

	/// <summary>
	/// 获取字符串
	/// </summary>
	/// <returns>The data text.</returns>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	public string GetDataText(string path)
	{
		if (this.dataList == null || !this.dataList.ContainsKey(path)) return "";

		WwwData wwwData = this.dataList [path];
		if (wwwData != null) return wwwData.www.text;

		return "";
	}

	/// <summary>
	/// 获取声音
	/// </summary>
	/// <returns>The data audio clip.</returns>
	/// <param name="path">Path.</param>
	public AudioClip GetDataAudioClip(string path)
	{
		if (this.dataList == null || !this.dataList.ContainsKey(path)) return null;
		
		WwwData wwwData = this.dataList [path];
		if (wwwData != null) return wwwData.www.audioClip;
		
		return null;
	}

	/// <summary>
	/// 获取 AssetBundle 对象
	/// </summary>
	/// <returns>The data asset bundle.</returns>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	public AssetBundle GetDataAssetBundle(string path)
	{
		if (this.dataList == null || !this.dataList.ContainsKey(path)) return null;

		WwwData wwwData = this.dataList [path];
		if (wwwData != null) return wwwData.www.assetBundle;

		return null;
	}

	/// <summary>
	/// 获取 Texture2D 对象
	/// </summary>
	/// <returns>The data texture.</returns>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	public Texture2D GetDataTexture(string path)
	{
		if (this.dataList == null || !this.dataList.ContainsKey(path)) return null;

		WwwData wwwData = this.dataList [path];
		if (wwwData != null) return wwwData.www.texture;

		return null;
	}

	/// <summary>
	/// 加载 GameObject 预设引用
	/// </summary>
	/// <returns>The game object by prefab name.</returns>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	/// <param name="prefabName">Prefab name.</param>
	/// <param name="mainAsset">If set to <c>true</c> main asset.</param>
	public GameObject CreateGameObjectByPrefabName (string path, string prefabName, bool mainAsset = false, bool unload = true)
	{
		AssetBundle assetBundle = this.GetDataAssetBundle (path);
		if (assetBundle == null) return null;

		GameObject prefabObject = null;
		if (mainAsset) 
		{
			prefabObject = (GameObject)assetBundle.mainAsset;
		} else {
			prefabObject = (GameObject)assetBundle.LoadAsset(prefabName, typeof(GameObject));
		}

		// 用完立刻卸载
		if (unload)
		{
			assetBundle.Unload (false);
		} else
		{
			if(this.assetList == null) this.assetList = new List<AssetBundle>();
			if(!this.assetList.Contains(assetBundle)) this.assetList.Add(assetBundle);
		}

		return prefabObject;
	}

	/// <summary>
	/// 加载 Texture2D 预设引用
	/// </summary>
	/// <returns>The texture by prefab name.</returns>
	/// <param name="path">Path.</param>
	/// <param name="loaderTypeEnum">Loader type enum.</param>
	/// <param name="prefabName">Prefab name.</param>
	/// <param name="mainAsset">If set to <c>true</c> main asset.</param>
	public Texture2D CreateTextureByPrefabName (string path, string prefabName, bool mainAsset = false, bool unload = true)
	{
		AssetBundle assetBundle = this.GetDataAssetBundle (path);
		if (assetBundle == null) return null;
		
		Texture2D prefabTexture = null;
		if (mainAsset) 
		{
			prefabTexture = (Texture2D)assetBundle.mainAsset;
		} else {
            prefabTexture = (Texture2D)assetBundle.LoadAsset(prefabName);
		}
		// 用完立刻卸载
		if (unload)
		{
			assetBundle.Unload (false);
		} else
		{
			if(this.assetList == null) this.assetList = new List<AssetBundle>();
			if(!this.assetList.Contains(assetBundle)) this.assetList.Add(assetBundle);
		}
		
		return prefabTexture;
	}

	/// <summary>
	/// 判断是否存在数据
	/// </summary>
	/// <returns><c>true</c>, if data was existsed, <c>false</c> otherwise.</returns>
	/// <param name="path">Path.</param>
	public bool ExistsData(string path)
	{
		if (this.dataList == null) return false;

		return this.dataList.ContainsKey (path);
	}
}
