using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoPanel : MonoBehaviour 
{
    //public UIRoot uiRoot;
	public Button btnOne;
    public Button btnMore;

	void Awake()
	{
        //MessageBoxManager.Init (uiRoot);

        //UIEventListener.Get (this.btnOne.gameObject).onClick = OnOneClickHandler;
        //UIEventListener.Get (this.btnMore.gameObject).onClick = OnMoreClickHandler;
	}

	private void OnOneClickHandler(GameObject o)
	{
		MessageBoxManager.Show ("这是单行文本提示框", MessageBoxEnum.Style.Ok, OnOneCallback);
	}

	private void OnMoreClickHandler(GameObject o)
	{
		MessageBoxManager.Show ("这是多行文本提示框\n显示“是”和“否”按钮！", MessageBoxEnum.Style.OkAndCancel, OnMoreCallback);
	}
	
	private void OnOneCallback(MessageBoxEnum.Result result)
	{
		Debug.Log ("单行文本提示框回调函数");
	}

	private void OnMoreCallback(MessageBoxEnum.Result result)
	{
		if(result == MessageBoxEnum.Result.Ok)
		{
			Debug.Log("您点击了是按钮！");
		}else{
			Debug.Log("您点击了否按钮！");
		}
	}
}
