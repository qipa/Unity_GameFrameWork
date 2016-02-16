using UnityEngine;
using System.Collections;

public class MessageBoxManager 
{
	/// <summary>
	/// 初始化弹出面板的父对象
	/// </summary>
	/// <param name="uiRoot">User interface root.</param>
    //public static void Init(UIRoot uiRoot)
    //{
    //    MessageBoxManager.uiRoot = uiRoot;
    //}
    //private static UIRoot uiRoot;
	private static MessageBoxPanel messageBoxPanel;

	/// <summary>
	/// 显示消息提示框
	/// </summary>
	/// <param name="context">Context.</param>
	/// <param name="style">Style.</param>
	/// <param name="callback">Callback.</param>
	public static void Show(string context, MessageBoxEnum.Style style, MessageBoxEnum.OnReceiveMessageBoxResult callback)
	{
		if (messageBoxPanel == null) 
		{
			GameObject gameObject = Resources.Load<GameObject>("MessageBoxPanel");
			if(gameObject != null)
			{
				GameObject messageBoxObject = (GameObject)GameObject.Instantiate(gameObject);
				if(messageBoxObject != null)
				{
					//messageBoxObject.transform.parent = MessageBoxManager.uiRoot.transform;
					messageBoxObject.transform.localPosition = new Vector3(0f, 0f, 0f);
					messageBoxObject.transform.localScale = new Vector3(1f, 1f, 1f);

					messageBoxPanel = messageBoxObject.GetComponent<MessageBoxPanel>();
				}
			}
		}
		if(messageBoxPanel != null)
		{
            //NGUITools.SetActive(messageBoxPanel.gameObject, true);
			messageBoxPanel.ShowMessageBox(context, style, callback);
		}
	}
}
