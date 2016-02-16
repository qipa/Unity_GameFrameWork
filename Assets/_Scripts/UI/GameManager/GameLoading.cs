using UnityEngine;
using System.Collections;
using TinyTeam.UI;

public class GameLoading : MonoBehaviour {

	void Start () {
        TTUIPage.ShowPage<UILoadingPage>();
	}

}
