using UnityEngine;
using System.Collections;

public class MessageBoxEnum
{
	public delegate void OnReceiveMessageBoxResult(MessageBoxEnum.Result result);

	public enum Style
	{
		Ok,
		OkAndCancel
	}

	public enum Result
	{
		Ok,
		Cancel
	}
}
