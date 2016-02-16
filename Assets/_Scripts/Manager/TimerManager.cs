using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimerManager
{
	private static Dictionary<string, TimerItem> dictList = new Dictionary<string, TimerItem>();

	/// <summary>
	/// 注册计时
	/// </summary>
	/// <param name="timerKey">Timer key.</param>
	/// <param name="totalNum">Total number.</param>
	/// <param name="delayTime">Delay time.</param>
	/// <param name="callback">Callback.</param>
	/// <param name="endCallback">End callback.</param>
	public static void Register(string timerKey, int totalNum, float delayTime, Action<int> callback, Action endCallback)
	{
		TimerItem timerItem = null;
		if(!dictList.ContainsKey(timerKey))
		{
			GameObject objectItem = new GameObject ();
			objectItem.name = timerKey;

			timerItem = objectItem.AddComponent<TimerItem> ();
			dictList.Add(timerKey, timerItem);
		}else
		{
			timerItem = dictList[timerKey];
		}

		if(timerItem != null)
		{
			timerItem.Run(totalNum, delayTime, callback, endCallback);
		}
	}

	/// <summary>
	/// 取消注册计时
	/// </summary>
	/// <param name="timerKey">Timer key.</param>
	public static void UnRegister(string timerKey)
	{
		if(!dictList.ContainsKey(timerKey)) return;

		TimerItem timerItem = dictList [timerKey];
		if(timerItem != null)
		{
			timerItem.Stop ();
			GameObject.Destroy(timerItem.gameObject);
		}
	}
}

class TimerItem : MonoBehaviour
{
	private int totalNum;
	private float delayTime;
	private Action<int> callback;
	private Action endCallback;

	private int currentIndex;

	public void Run(int totalNum, float delayTime, Action<int> callback, Action endCallback)
	{
		this.Stop ();

		this.currentIndex = 0;

		this.totalNum = totalNum;
		this.delayTime = delayTime;
		this.callback = callback;
		this.endCallback = endCallback;

		this.StartCoroutine ("EnumeratorAction");
	}

	public void Stop()
	{
		this.StopCoroutine ("EnumeratorAction");
	}

	private IEnumerator EnumeratorAction()
	{
		yield return new WaitForSeconds (this.delayTime);

		this.currentIndex ++;
		if(this.callback != null) this.callback(this.currentIndex);

		if(this.totalNum != -1)
		{
			if(this.currentIndex >= this.totalNum)
			{
				if(this.endCallback != null) this.endCallback();
				yield break;
			}
		}
		this.StartCoroutine("EnumeratorAction");
	}
}

