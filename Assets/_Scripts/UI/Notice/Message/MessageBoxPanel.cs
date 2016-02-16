using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBoxPanel : MonoBehaviour 
{
	public Text lblNote;
	public Button btnSubmit;
    public Button btnYes;
    public Button btnNo;

	private MessageBoxEnum.OnReceiveMessageBoxResult callback;

    void Awake()
    {
        //UIEventListener.Get (this.btnSubmit.gameObject).onClick = OnSubmitHandler;
        //UIEventListener.Get (this.btnYes.gameObject).onClick = OnSubmitHandler;
        //UIEventListener.Get (this.btnNo.gameObject).onClick = OnCancelHandler;
        this.ResetButtons();
    }

	private void ResetButtons()
	{
        //NGUITools.SetActive (this.btnSubmit.gameObject, false);
        //NGUITools.SetActive (this.btnYes.gameObject, false);
        //NGUITools.SetActive (this.btnNo.gameObject, false);
	}

	public void ShowMessageBox(string context, MessageBoxEnum.Style style, MessageBoxEnum.OnReceiveMessageBoxResult callback)
	{
		this.lblNote.text = context;
		this.callback = callback;

		this.ResetButtons ();

		if (style == MessageBoxEnum.Style.Ok) 
		{
			//NGUITools.SetActive (this.btnSubmit.gameObject, true);
		} else if (style == MessageBoxEnum.Style.OkAndCancel) {
			//NGUITools.SetActive (this.btnYes.gameObject, true);
			//NGUITools.SetActive(this.btnNo.gameObject, true);
		}
	}

	private void OnSubmitHandler(GameObject o)
	{
		//NGUITools.SetActive (this.gameObject, false);
		if (callback != null) 
		{
			callback.Invoke(MessageBoxEnum.Result.Ok);
		}
	}

	private void OnCancelHandler(GameObject o)
	{
		//NGUITools.SetActive (this.gameObject, false);
		if (callback != null) 
		{
			callback.Invoke(MessageBoxEnum.Result.Cancel);
		}
	}
}
