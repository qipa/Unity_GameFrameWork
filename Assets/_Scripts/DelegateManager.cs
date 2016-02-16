using UnityEngine;
using System.Collections;

public class DelegateManager : MonoBehaviour {

    public delegate void VoidDelegate(GameObject go);
    public delegate void VectorDelegate(Vector2 delta);
    public delegate void BoolDelegate(bool state);

    public event VoidDelegate BuildCompOppositeCall;

    public static DelegateManager mIns;

    void Awake()
    {
        mIns = this;
    }

    public void AddOppositeDelegate(VoidDelegate mDelegate)
    {
        BuildCompOppositeCall += mDelegate;
    }

    public void RemoveOppositeDelegate(VoidDelegate mDelegate)
    {
        BuildCompOppositeCall -= mDelegate;
    }

    public void ExecuteOppositeDelegate(GameObject go)
    {
        BuildCompOppositeCall(go);
    }

}
