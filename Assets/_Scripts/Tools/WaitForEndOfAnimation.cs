using UnityEngine;
using System.Collections;

public class WaitForEndOfAnimation : MonoBehaviour {

	AnimationState m_animState;

    public WaitForEndOfAnimation(AnimationState animState)
    {
        m_animState = animState;
    }
    //-- IEnumerator Interface
    public object Current
    {
        get
        {
            return null;
        }
    }

    //-- IEnumerator Interface
    public bool MoveNext()
    {
        return m_animState.enabled;
    }

    //-- IEnumerator Interface
    public void Reset()
    {
    }
}
