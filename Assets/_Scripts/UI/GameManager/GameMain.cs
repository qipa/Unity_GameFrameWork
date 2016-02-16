using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;

public class GameMain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        TTUIPage.ShowPage<UITopBar>();
        TTUIPage.ShowPage<UIMainPage>();

        //TimerManager.Register("update", 10, 2, null, null);

        //Cothread spam = new Cothread(MyAwesomeTask());
        //new Cothread(TaskKiller(5, spam)); 
    }

    IEnumerator MyAwesomeTask()
    {
        while (true)
        {
            Debug.Log("Logcat iz in ur consolez, spammin u wif messagez.");
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator TaskKiller(float delay, Cothread t)
    {
        yield return new WaitForSeconds(delay);
        t.Stop();
        //TimerManager.UnRegister("update");
    }
}
