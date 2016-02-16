using UnityEngine;
using System.Collections;

namespace Common
{

    public enum GameState
    {
        Normal
    }

    public enum TaskState
    {
        NotStart,
        Accept,
        Complete,
        Reward
    }

    public enum TaskType
    {
        Main,
        Reward,
        Daily
    }

}
