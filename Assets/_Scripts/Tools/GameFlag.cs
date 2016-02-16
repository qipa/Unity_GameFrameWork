using UnityEngine;
using System.Collections;

public class GameFlag {

    /// <summary>
    /// 标志值
    /// </summary>
    private long m_uValue = 0;
    public long Value
    {
        get { return m_uValue; }
        set { m_uValue = value; }
    }

    public GameFlag()
    {

    }

    public GameFlag(long val)
    {
        Value = val;
    }

    public long AddFlag(long uFlag)
    {
        m_uValue |= uFlag;
        return m_uValue;
    }
    
    public long RemoveFlag(long uFlag)
    {
        m_uValue &= ~uFlag;
        return m_uValue;
    }

    public long ModifyFlag(bool addOrRemove, long uFlag)
    {
        return addOrRemove ? AddFlag(uFlag) : RemoveFlag(uFlag);
    }

    public bool HasFlag(long uFlag)
    {
        return ((m_uValue & uFlag) != 0);
    }

    public bool HasAllZero()
    {
        return 0 == Value;
    }
}
