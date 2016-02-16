using UnityEngine;
using System.Collections;

public class Cothread {
    CoroutinesManager.CoroutineState task;
	public bool Running {  
        get {  
            return task.Running;  
        }  
    }  
      
    public bool Paused {  
        get {  
            return task.Paused;  
        }  
    }  
      
    public delegate void FinishedHandler(bool manual);  
      
    public event FinishedHandler Finished;

    public Cothread(IEnumerator c, bool autoStart = true)  
    {
        task = CoroutinesManager.CreateTask(c);  
        task.Finished += TaskFinished;  
        if(autoStart)  
            Start();  
    }  
      
    public void Start()  
    {  
        task.Start();  
    }  
  
    public void Stop()  
    {  
        task.Stop();  
    }  
      
    public void Pause()  
    {  
        task.Pause();  
    }  
      
    public void Unpause()  
    {  
        task.Unpause();  
    }  
      
    void TaskFinished(bool manual)  
    {  
        FinishedHandler handler = Finished;  
        if(handler != null)  
            handler(manual);  
    }
}
